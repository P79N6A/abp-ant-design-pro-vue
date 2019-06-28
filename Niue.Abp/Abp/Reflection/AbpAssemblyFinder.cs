using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Niue.Abp.Abp.Modules;

namespace Niue.Abp.Abp.Reflection
{
    public class AbpAssemblyFinder : IAssemblyFinder
    {
        private readonly IAbpModuleManager _moduleManager;

        public AbpAssemblyFinder(IAbpModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public List<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleManager.Modules)
            {
                assemblies.Add(module.Assembly);
                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}