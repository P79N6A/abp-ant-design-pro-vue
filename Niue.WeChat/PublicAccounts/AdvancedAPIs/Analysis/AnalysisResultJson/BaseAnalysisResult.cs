/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：BaseAnalysisResult.cs
    文件功能描述：分析数据接口返回结果基类
    
    
    创建标识：Senparc - 20150309
    
    修改标识：Senparc - 20150310
    修改描述：整理接口
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Analysis.AnalysisResultJson
{
    public interface IBaseAnalysisResult
    {
        object ListObj { get; set; }
    }

    public abstract class BaseAnalysisResult : WxJsonResult, IBaseAnalysisResult
    {
        public object ListObj { get; set; }

        //public BaseAnalysisResult()
        //{
        //    list = new List<BaseAnalysisObject>();
        //}
    }
}
