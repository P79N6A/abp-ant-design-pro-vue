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
    public class UserOrganizationUnitRemover : 
        IEventHandler<EntityDeletedEventData<AbpUserBase>>, 
        ITransientDependency
    {
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserOrganizationUnitRemover(
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IUnitOfWorkManager unitOfWorkManager)
        {
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public virtual void HandleEvent(EntityDeletedEventData<AbpUserBase> eventData)
        {
            using (_unitOfWorkManager.Current.SetTenantId(eventData.Entity.TenantId))
            {
                _userOrganizationUnitRepository.Delete(
                    uou => uou.UserId == eventData.Entity.Id
                );
            }
        }
    }
}