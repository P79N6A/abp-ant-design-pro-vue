﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：SubmerChantBatchGetJsonResult.cs
    文件功能描述：批量拉取子商户信息的返回结果
    
    
    创建标识：Senparc - 20160520
    
    修改标识：Senparc - 20160520
    修改描述：整理接口
----------------------------------------------------------------*/

using System.Collections.Generic;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Card.Submerchat
{
    /// <summary>
    /// 批量拉取子商户信息的返回结果
    /// </summary>
   public class SubmerChantBatchGetJsonResult : SubmerChantSubmitJsonResult
    {
      public List<SubmerChantBatchGet_InfoList> info_list { get; set; }
     }
   public class SubmerChantBatchGet_InfoList
   {
       public List<SubmerChantSubmit_info> info { get; set; }
       /// <summary>
       /// 拉渠道列表中最后一个子商户的id
       /// </summary>
       public int next_begin_id { get; set; }
   }
}
