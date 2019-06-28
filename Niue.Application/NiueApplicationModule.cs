using System.Reflection;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Abp.Abp.Modules;
using Niue.Application.Users.Dto;
using Niue.Core;
using Niue.Core.Users;

namespace Niue.Application
{
    [DependsOn(typeof(NiueCoreModule), typeof(AbpAutoMapperModule))]
    public class NiueApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
                mapper.CreateMap<User, UserDto>()
                    .ForMember(dto => dto.CreationTime, e => e.MapFrom(o => o.CreationTime.ToString("yyyy-MM-dd")))
                    .ForMember(dto => dto.LastLoginTime,
                        e => e.MapFrom(o => o.LastLoginTime.HasValue ? o.LastLoginTime.Value.ToString("yyyy年M月d日 HH:mm:ss") : ""));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
