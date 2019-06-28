using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Net.Mail;

namespace Niue.Abp.Zero.Abp.Zero.IdentityFramework
{
    public class IdentityEmailMessageService : IIdentityMessageService, ITransientDependency
    {
        private readonly IEmailSender _emailSender;

        public IdentityEmailMessageService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public virtual Task SendAsync(IdentityMessage message)
        {
            return _emailSender.SendAsync(message.Destination, message.Subject, message.Body);
        }
    }
}
