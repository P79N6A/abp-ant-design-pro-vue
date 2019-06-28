using System;
using Castle.Facilities.Logging;
using Niue.Abp.Abp.Castle.Log4Net.Castle.Logging.Log4Net;
using Niue.Abp.Abp.Web.Web;

namespace Niue.Web
{
    public class MvcApplication : AbpWebApplication<NiueWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            base.Application_Start(sender, e);
        }
    }
}
