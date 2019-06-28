using System;
using System.Collections.Generic;
using AutoMapper;

namespace Niue.Abp.Abp.AutoMapper.AutoMapper
{
    public class AbpAutoMapperConfiguration : IAbpAutoMapperConfiguration
    {
        public List<Action<IMapperConfigurationExpression>> Configurators { get; }

        public AbpAutoMapperConfiguration()
        {
            Configurators = new List<Action<IMapperConfigurationExpression>>();
        }
    }
}