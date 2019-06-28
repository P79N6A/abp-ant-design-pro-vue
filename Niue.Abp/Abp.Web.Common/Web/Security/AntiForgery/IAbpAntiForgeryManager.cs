﻿namespace Niue.Abp.Abp.Web.Common.Web.Security.AntiForgery
{
    public interface IAbpAntiForgeryManager
    {
        IAbpAntiForgeryConfiguration Configuration { get; }

        string GenerateToken();
    }
}
