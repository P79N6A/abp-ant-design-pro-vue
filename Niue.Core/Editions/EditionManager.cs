using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Zero.Abp.Zero.Application.Editions;
using Niue.Abp.Zero.Abp.Zero.Application.Features;

namespace Niue.Core.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository, 
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore
            )
        {
        }
    }
}
