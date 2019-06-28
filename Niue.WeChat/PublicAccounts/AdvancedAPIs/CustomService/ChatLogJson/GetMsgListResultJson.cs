﻿using System;
using System.Collections.Generic;
using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.CustomService.ChatLogJson
{
    public class GetMsgListResultJson : WxJsonResult
    {
        public List<GetMsgList> recordList { get; set; }
        public int number { get; set; }
        public long msgid { get; set; }
    }

    public class GetMsgList
    {
        public string openid { get; set; }
        public string opercode { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
        public string worker { get; set; }
    }
}
