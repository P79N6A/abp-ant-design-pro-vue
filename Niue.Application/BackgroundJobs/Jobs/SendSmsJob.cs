using Niue.Abp.Abp.BackgroundJobs;
using Niue.Abp.Abp.Dependency;
using Niue.Application.BackgroundJobs.Args;
using Niue.Common;

namespace Niue.Application.BackgroundJobs.Jobs
{
    public class SendSmsJob : BackgroundJob<SendSmsArgs>, ITransientDependency
    {
        public override void Execute(SendSmsArgs args)
        {
            SmsHelper.SendSms(args.Mobile, args.Content, args.Xh);
        }
    }
}
