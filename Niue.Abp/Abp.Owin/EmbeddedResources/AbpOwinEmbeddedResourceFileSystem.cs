using System.Collections.Generic;
using Microsoft.Owin.FileSystems;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Resources.Embedded;
using Niue.Abp.Abp.Web.Common.Web.Configuration;

namespace Niue.Abp.Abp.Owin.EmbeddedResources
{
    public class AbpOwinEmbeddedResourceFileSystem : IFileSystem, ITransientDependency
    {
        private readonly IEmbeddedResourceManager _embeddedResourceManager;
        private readonly IWebEmbeddedResourcesConfiguration _configuration;
        private readonly IFileSystem _physicalFileSystem;

        public AbpOwinEmbeddedResourceFileSystem(
            IEmbeddedResourceManager embeddedResourceManager,
            IWebEmbeddedResourcesConfiguration configuration,
            string rootFolder)
        {
            _embeddedResourceManager = embeddedResourceManager;
            _configuration = configuration;
            _physicalFileSystem = new PhysicalFileSystem(rootFolder);
        }

        public bool TryGetFileInfo(string subpath, out IFileInfo fileInfo)
        {
            if (_physicalFileSystem.TryGetFileInfo(subpath, out fileInfo))
            {
                return true;
            }

            var resource = _embeddedResourceManager.GetResource(subpath);

            if (resource == null || IsIgnoredFile(resource))
            {
                fileInfo = null;
                return false;
            }

            fileInfo = new AbpOwinEmbeddedResourceFileInfo(resource);
            return true;
        }

        public bool TryGetDirectoryContents(string subpath, out IEnumerable<IFileInfo> contents)
        {
            if (_physicalFileSystem.TryGetDirectoryContents(subpath, out contents))
            {
                return true;
            }

            //TODO: Implement..?

            contents = null;
            return false;
        }

        private bool IsIgnoredFile(EmbeddedResourceItem resource)
        {
            return resource.FileExtension != null && _configuration.IgnoredFileExtensions.Contains(resource.FileExtension);
        }
    }
}