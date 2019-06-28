using System.Threading.Tasks;

namespace Niue.Abp.Abp.Web.Common.Web.Navigation
{
    /// <summary>
    /// Used to generate navigation scripts.
    /// </summary>
    public interface INavigationScriptManager
    {
        /// <summary>
        /// Used to generate navigation scripts.
        /// </summary>
        /// <returns></returns>
        Task<string> GetScriptAsync();
    }
}
