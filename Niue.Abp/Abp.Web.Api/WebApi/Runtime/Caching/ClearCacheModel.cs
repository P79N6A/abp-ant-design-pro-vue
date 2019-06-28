namespace Niue.Abp.Abp.Web.Api.WebApi.Runtime.Caching
{
    public class ClearCacheModel
    {
        public string Password { get; set; }

        public string[] Caches { get; set; }
    }
}