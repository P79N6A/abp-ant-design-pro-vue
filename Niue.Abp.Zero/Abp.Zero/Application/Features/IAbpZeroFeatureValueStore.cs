using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Features;

namespace Niue.Abp.Zero.Abp.Zero.Application.Features
{
    public interface IAbpZeroFeatureValueStore : IFeatureValueStore
    {
        Task<string> GetValueOrNullAsync(int tenantId, string featureName);
        Task<string> GetEditionValueOrNullAsync(int editionId, string featureName);
        Task SetEditionFeatureValueAsync(int editionId, string featureName, string value);
    }
}