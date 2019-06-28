using System;
using System.Collections.Generic;
using System.Reflection;

namespace Niue.Abp.Abp.PlugIns
{
    public interface IPlugInSource
    {
        List<Assembly> GetAssemblies();

        List<Type> GetModules();
    }
}