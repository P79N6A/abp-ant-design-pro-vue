﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：AnalysisResultJson.cs
    文件功能描述：分析数据接口返回结果
    
    
    创建标识：Senparc - 20150309
    
    修改标识：Senparc - 20150310
    修改描述：整理接口
----------------------------------------------------------------*/

using System.Collections.Generic;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Analysis.AnalysisResultJson
{
    /// <summary>
    /// 分析数据接口返回结果
    /// </summary>
    public class AnalysisResultJson<T> : BaseAnalysisResult
    {
        public List<T> list
        {
            get { return ListObj as List<T>; }
            set { ListObj = value; }
        }

        public AnalysisResultJson()
        {
            ListObj = new List<T>();
        }
    }

}
