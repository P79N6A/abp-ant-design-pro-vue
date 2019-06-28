using System;
using Niue.Abp.Abp.Dependency;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories
{
    public interface IEntityFrameworkGenericRepositoryRegistrar
    {
        void RegisterForDbContext(Type dbContextType, IIocManager iocManager);
    }
}