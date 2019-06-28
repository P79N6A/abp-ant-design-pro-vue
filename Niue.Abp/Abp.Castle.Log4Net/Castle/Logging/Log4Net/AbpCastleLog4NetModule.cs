using Niue.Abp.Abp.Modules;

namespace Niue.Abp.Abp.Castle.Log4Net.Castle.Logging.Log4Net
{
    /// <summary>
    /// ABP Castle Log4Net module.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpCastleLog4NetModule : AbpModule
    {

    }
}