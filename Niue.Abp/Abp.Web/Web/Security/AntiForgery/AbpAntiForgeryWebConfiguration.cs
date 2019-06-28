using System.Collections.Generic;
using Niue.Abp.Abp.Web.Common.Web;

namespace Niue.Abp.Abp.Web.Web.Security.AntiForgery
{
    public class AbpAntiForgeryWebConfiguration : IAbpAntiForgeryWebConfiguration
    {
        public bool IsEnabled { get; set; }

        public HashSet<HttpVerb> IgnoredHttpVerbs { get; }

        public AbpAntiForgeryWebConfiguration()
        {
            IsEnabled = true;
            IgnoredHttpVerbs = new HashSet<HttpVerb> { HttpVerb.Get, HttpVerb.Head, HttpVerb.Options, HttpVerb.Trace };
        }
    }
}