﻿using System;
using AutoMapper;
using Niue.Abp.Abp.Collections.Extensions;

namespace Niue.Abp.Abp.AutoMapper.AutoMapper
{
    public class AutoMapAttribute : AutoMapAttributeBase
    {
        public AutoMapAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                configuration.CreateMap(type, targetType, MemberList.Source);
                configuration.CreateMap(targetType, type, MemberList.Destination);
            }
        }
    }
}