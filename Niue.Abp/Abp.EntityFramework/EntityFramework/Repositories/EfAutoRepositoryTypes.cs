using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.EntityFramework.Common;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories
{
    public static class EfAutoRepositoryTypes
    {
        public static AutoRepositoryTypesAttribute Default { get; private set; }

        static EfAutoRepositoryTypes()
        {
            Default = new AutoRepositoryTypesAttribute(
                typeof(IRepository<>),
                typeof(IRepository<,>),
                typeof(EfRepositoryBase<,>),
                typeof(EfRepositoryBase<,,>)
            );
        }
    }
}