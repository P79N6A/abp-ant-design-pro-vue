using System;
using System.Collections.Generic;

namespace Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Configuration
{
    public interface IApiProxyScriptingConfiguration
    {
        /// <summary>
        /// Used to add/replace proxy script generators. 
        /// </summary>
        IDictionary<string, Type> Generators { get; }
    }
}