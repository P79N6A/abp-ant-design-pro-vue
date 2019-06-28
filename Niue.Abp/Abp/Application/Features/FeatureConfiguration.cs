﻿using Niue.Abp.Abp.Collections;

namespace Niue.Abp.Abp.Application.Features
{
    internal class FeatureConfiguration : IFeatureConfiguration
    {
        public ITypeList<FeatureProvider> Providers { get; private set; }

        public FeatureConfiguration()
        {
            Providers = new TypeList<FeatureProvider>();
        }
    }
}