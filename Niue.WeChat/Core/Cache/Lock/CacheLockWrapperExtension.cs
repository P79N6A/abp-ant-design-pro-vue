using System;
using Niue.WeChat.Core.Cache.ContainerCacheStragegy;

namespace Niue.WeChat.Core.Cache.Lock
{
    public static class CacheLockWrapperExtension
    {
        public static CacheLockWrapper InstanceCacheLockWrapper(this IContainerCacheStragegy stragegy, string resourceName, string key, int retryCount, TimeSpan retryDelay)
        {
            return new CacheLockWrapper(stragegy, resourceName, key, retryCount, retryDelay);
        }

        public static CacheLockWrapper InstanceCacheLockWrapper(this IContainerCacheStragegy stragegy, string resourceName, string key)
        {
            return InstanceCacheLockWrapper(stragegy, resourceName, key, 0, new TimeSpan());
        }
    }
}
