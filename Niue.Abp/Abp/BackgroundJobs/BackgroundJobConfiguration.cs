using Niue.Abp.Abp.Configuration.Startup;

namespace Niue.Abp.Abp.BackgroundJobs
{
    internal class BackgroundJobConfiguration : IBackgroundJobConfiguration
    {
        public bool IsJobExecutionEnabled { get; set; }
        
        public IAbpStartupConfiguration AbpConfiguration { get; private set; }

        public BackgroundJobConfiguration(IAbpStartupConfiguration abpConfiguration)
        {
            AbpConfiguration = abpConfiguration;

            IsJobExecutionEnabled = true;
        }
    }
}