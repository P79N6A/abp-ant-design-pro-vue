using System;
using System.Collections.Generic;
using AutoMapper;

namespace Niue.Abp.Abp.AutoMapper.AutoMapper
{
    public interface IAbpAutoMapperConfiguration
    {
        List<Action<IMapperConfigurationExpression>> Configurators { get; }
    }
}