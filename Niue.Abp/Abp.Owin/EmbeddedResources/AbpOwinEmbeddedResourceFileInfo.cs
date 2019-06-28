using System;
using System.IO;
using Microsoft.Owin.FileSystems;
using Niue.Abp.Abp.Resources.Embedded;

namespace Niue.Abp.Abp.Owin.EmbeddedResources
{
    public class AbpOwinEmbeddedResourceFileInfo : IFileInfo
    {
        public long Length => _resource.Content.Length;

        public string PhysicalPath => null;

        public string Name => _resource.FileName;

        public DateTime LastModified => _resource.LastModifiedUtc;

        public bool IsDirectory => false;

        private readonly EmbeddedResourceItem _resource;

        public AbpOwinEmbeddedResourceFileInfo(EmbeddedResourceItem resource)
        {
            _resource = resource;
        }

        public Stream CreateReadStream()
        {
            return new MemoryStream(_resource.Content);
        }
    }
}