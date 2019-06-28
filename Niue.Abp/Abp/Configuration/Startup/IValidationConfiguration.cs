using System;
using System.Collections.Generic;

namespace Niue.Abp.Abp.Configuration.Startup
{
    public interface IValidationConfiguration
    {
        List<Type> IgnoredTypes { get; }
    }
}