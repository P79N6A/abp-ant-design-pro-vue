using System.Web.Caching;
using Niue.Abp.Abp.Resources.Embedded;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Resources.Embedded
{
    public class EmbeddedResourceItemCacheDependency : CacheDependency
    {
        public EmbeddedResourceItemCacheDependency(EmbeddedResourceItem resource)
        {
            SetUtcLastModified(resource.LastModifiedUtc);
        }
    }
}