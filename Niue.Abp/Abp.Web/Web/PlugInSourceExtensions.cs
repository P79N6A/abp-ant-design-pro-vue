using System;
using System.Web.Compilation;
using Niue.Abp.Abp.Logging;
using Niue.Abp.Abp.PlugIns;

namespace Niue.Abp.Abp.Web.Web
{
    public static class PlugInSourceListExtensions
    {
        public static void AddToBuildManager(this PlugInSourceList plugInSourceList)
        {
            foreach (var plugInAssembly in plugInSourceList.GetAllAssemblies())
            {
                try
                {
                    LogHelper.Logger.Debug($"Adding {plugInAssembly.FullName} to BuildManager");
                    BuildManager.AddReferencedAssembly(plugInAssembly);
                }
                catch (Exception ex)
                {
                    LogHelper.Logger.Warn(ex.ToString(), ex);
                }
            }
        }
    }
}
