using Hangfire.Common;
using Hangfire.Server;
using Niue.Abp.Abp.BackgroundJobs;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Events.Bus;
using Niue.Abp.Abp.Events.Bus.Exceptions;

namespace Niue.Abp.Abp.HangFire.Hangfire
{
    public class AbpHangfireJobExceptionFilter : JobFilterAttribute, IServerFilter, ITransientDependency
    {
        public IEventBus EventBus { get; set; }

        public AbpHangfireJobExceptionFilter()
        {
            EventBus = NullEventBus.Instance;
        }

        public void OnPerforming(PerformingContext filterContext)
        {
        }

        public void OnPerformed(PerformedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                EventBus.Trigger(
                    this,
                    new AbpHandledExceptionData(
                        new BackgroundJobException(
                            "A background job execution is failed on Hangfire. See inner exception for details. Use JobObject to get Hangfire background job object.",
                            filterContext.Exception
                        )
                        {
                            JobObject = filterContext.BackgroundJob
                        }
                    )
                );
            }
        }
    }
}
