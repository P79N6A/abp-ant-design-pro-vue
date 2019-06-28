using System.Reflection;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Web.Common.Web;

namespace Niue.Abp.Abp.Owin
{
    /// <summary>
    /// OWIN integration module for ABP.
    /// </summary>
    [DependsOn(typeof (AbpWebCommonModule))]
    public class AbpOwinModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
