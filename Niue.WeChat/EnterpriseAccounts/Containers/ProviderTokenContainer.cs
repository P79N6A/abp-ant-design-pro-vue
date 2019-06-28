﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc

    文件名：ProviderTokenContainer.cs
    文件功能描述：通用接口ProviderToken容器，用于自动管理ProviderToken，如果过期会重新获取


    创建标识：Senparc - 20150313

    修改标识：Senparc - 20150313
    修改描述：整理接口

    修改标识：Senparc - 20160206
    修改描述：将public object Lock更改为internal object Lock

    修改标识：Senparc - 20160312
    修改描述：升级Container，继承自BaseContainer<JsApiTicketBag>

    修改标识：Senparc - 20160318
    修改描述：v3.3.4 使用FlushCache.CreateInstance使注册过程立即生效

    修改标识：Senparc - 20160717
    修改描述：v3.3.8 添加注册过程中的Name参数
    
    修改标识：Senparc - 20160803
    修改描述：v4.1.2 使用ApiUtility.GetExpireTime()方法处理过期
 
    修改标识：Senparc - 20160804
    修改描述：v4.1.3 增加TryGetTokenAsync，GetTokenAsync，GetTokenResultAsync的异步方法
    
    修改标识：Senparc - 20160813
    修改描述：v4.1.5 添加TryReRegister()方法，处理分布式缓存重启（丢失）的情况

    修改标识：Senparc - 20160813
    修改描述：v4.1.6 完善GetToken()方法

    修改标识：Senparc - 20160813
    修改描述：v4.1.8 修改命名空间为Senparc.Weixin.QY.Containers

----------------------------------------------------------------*/

using System;
using System.Threading.Tasks;
using Niue.WeChat.Core.Containers;
using Niue.WeChat.Core.Utilities.CacheUtility;
using Niue.WeChat.Core.Utilities.WeixinUtility;
using Niue.WeChat.EnterpriseAccounts.CommonAPIs;
using Niue.WeChat.EnterpriseAccounts.Entities.JsonResult;
using Niue.WeChat.EnterpriseAccounts.Exceptions;

namespace Niue.WeChat.EnterpriseAccounts.Containers
{
    /// <summary>
    /// ProviderTokenBag
    /// </summary>
    [Serializable]
    public class ProviderTokenBag : BaseContainerBag
    {
        /// <summary>
        /// CorpId
        /// </summary>
        public string CorpId
        {
            get { return _corpId; }
            set { SetContainerProperty(ref _corpId, value); }
        }
        /// <summary>
        /// CorpSecret
        /// </summary>
        public string CorpSecret
        {
            get { return _corpSecret; }
            set { SetContainerProperty(ref _corpSecret, value); }
        }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireTime
        {
            get { return _expireTime; }
            set { SetContainerProperty(ref _expireTime, value); }
        }
        /// <summary>
        /// ProviderTokenResult
        /// </summary>
        public ProviderTokenResult ProviderTokenResult
        {
            get { return _providerTokenResult; }
            set { SetContainerProperty(ref _providerTokenResult, value); }
        }

        /// <summary>
        /// 只针对这个CorpId的锁
        /// </summary>
        internal object Lock = new object();

        private string _corpId;
        private string _corpSecret;
        private DateTime _expireTime;
        private ProviderTokenResult _providerTokenResult;
    }

    /// <summary>
    /// 通用接口ProviderToken容器，用于自动管理ProviderToken，如果过期会重新获取
    /// </summary>
    public class ProviderTokenContainer : BaseContainer<ProviderTokenBag>
    {
        private const string UN_REGISTER_ALERT = "此CorpId尚未注册，ProviderTokenContainer.Register完成注册（全局执行一次即可）！";


        /// <summary>
        /// 注册应用凭证信息，此操作只是注册，不会马上获取Token，并将清空之前的Token，
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="name">标记Provider名称（如微信公众号名称），帮助管理员识别</param>
        public static void Register(string corpId, string corpSecret, string name = null)
        {
            RegisterFunc = () =>
            {
                using (FlushCache.CreateInstance())
                {
                    var bag = new ProviderTokenBag
                    {
                        Name = name,
                        CorpId = corpId,
                        CorpSecret = corpSecret,
                        ExpireTime = DateTime.MinValue,
                        ProviderTokenResult = new ProviderTokenResult()
                    };
                    Update(corpId, bag);
                    return bag;
                }
            };
            RegisterFunc();
        }


        #region 同步方法

        /// <summary>
        /// 使用完整的应用凭证获取Token，如果不存在将自动注册
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static string TryGetToken(string corpId, string corpSecret, bool getNewToken = false)
        {
            if (!CheckRegistered(corpId) || getNewToken)
            {
                Register(corpId, corpSecret);
            }
            return GetToken(corpId, getNewToken);
        }

        /// <summary>
        /// 获取可用Token
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static string GetToken(string corpId, bool getNewToken = false)
        {
            return GetTokenResult(corpId, getNewToken).provider_access_token;
        }

        /// <summary>
        /// 获取可用Token
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static ProviderTokenResult GetTokenResult(string corpId, bool getNewToken = false)
        {
            if (!CheckRegistered(corpId))
            {
                throw new WeixinQyException(UN_REGISTER_ALERT);
            }

            var providerTokenBag = TryGetItem(corpId);
            lock (providerTokenBag.Lock)
            {
                if (getNewToken || providerTokenBag.ExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    providerTokenBag.ProviderTokenResult = CommonApi.GetProviderToken(providerTokenBag.CorpId,
                        providerTokenBag.CorpSecret);
                    providerTokenBag.ExpireTime = ApiUtility.GetExpireTime(providerTokenBag.ProviderTokenResult.expires_in);
                }
            }
            return providerTokenBag.ProviderTokenResult;
        }

        ///// <summary>
        ///// 检查是否已经注册
        ///// </summary>
        ///// <param name="corpId"></param>
        ///// <returns></returns>
        ///// 此接口无异步方法
        //public new static bool CheckRegistered(string corpId)
        //{
        //    return Cache.CheckExisted(corpId);
        //}
        #endregion

        #region 异步方法
        /// <summary>
        /// 【异步方法】使用完整的应用凭证获取Token，如果不存在将自动注册
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static async Task<string> TryGetTokenAsync(string corpId, string corpSecret, bool getNewToken = false)
        {
            if (!CheckRegistered(corpId) || getNewToken)
            {
                Register(corpId, corpSecret);
            }
            return await GetTokenAsync(corpId);
        }

        /// <summary>
        /// 【异步方法】获取可用Token
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static async Task<string> GetTokenAsync(string corpId, bool getNewToken = false)
        {
            var result = await GetTokenResultAsync(corpId, getNewToken);
            return result.provider_access_token;
        }

        /// <summary>
        /// 【异步方法】获取可用Token
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static async Task<ProviderTokenResult> GetTokenResultAsync(string corpId, bool getNewToken = false)
        {
            if (!CheckRegistered(corpId))
            {
                throw new WeixinQyException(UN_REGISTER_ALERT);
            }

            var providerTokenBag = TryGetItem(corpId);
            //lock (providerTokenBag.Lock)
            {
                if (getNewToken || providerTokenBag.ExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    var providerTokenResult = await CommonApi.GetProviderTokenAsync(providerTokenBag.CorpId,
                        providerTokenBag.CorpSecret);
                    providerTokenBag.ProviderTokenResult = providerTokenResult;
                    //providerTokenBag.ProviderTokenResult = CommonApi.GetProviderToken(providerTokenBag.CorpId,
                    //    providerTokenBag.CorpSecret);
                    providerTokenBag.ExpireTime = ApiUtility.GetExpireTime(providerTokenBag.ProviderTokenResult.expires_in);
                }
            }
            return providerTokenBag.ProviderTokenResult;
        }
        #endregion
    }
}
