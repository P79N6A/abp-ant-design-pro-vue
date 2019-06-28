using System.Collections.Generic;

namespace Niue.Abp.Abp.Resources.Embedded
{
    public interface IEmbeddedResourcesConfiguration
    {
        List<EmbeddedResourceSet> Sources { get; }
    }
}