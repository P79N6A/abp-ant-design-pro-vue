using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Events.Bus.Entities;
using Niue.Abp.Abp.Events.Bus.Handlers;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    /// <summary>
    /// Removes the user from all organization units when a user is deleted.
    /// </summary>
    public class UserRoleRemover :
        IEventHandler<EntityDeletedEventData<AbpUserBase>>,
        ITransientDependency
    {
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserRoleRemover(
            IUnitOfWorkManager unitOfWorkManager, 
            IRepository<UserRole, long> userRoleRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userRoleRepository = userRoleRepository;
        }

        [UnitOfWork]
        public virtual void HandleEvent(EntityDeletedEventData<AbpUserBase> eventData)
        {
            using (_unitOfWorkManager.Current.SetTenantId(eventData.Entity.TenantId))
            {
                _userRoleRepository.Delete(
                    ur => ur.UserId == eventData.Entity.Id
                );
            }
        }
    }
}