using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Core.Entities.Cities;
using Niue.Core.Enums;

namespace Niue.Application.ApplicationServices.Cities.Dto
{
    [Serializable]
    [AutoMapFrom(typeof(City))]
    [Description("CityDto")]
    public class CityDto : FullAuditedEntityDto<int>
    {
		[Description("Name")]
		public virtual string Name { get; set; }
		
		[Description("SpellAll")]
		public virtual string SpellAll { get; set; }
		
		[Description("SpellShort")]
		public virtual string SpellShort { get; set; }
		
		[Description("Sort")]
		public virtual int Sort { get; set; }
		
		[Description("IsHot")]
		public virtual bool IsHot { get; set; }
		
		[Description("Province_Id")]
		public virtual int ProvinceId { get; set; }
		
		[Description("Province")]
		public virtual CityDto Province { get; set; }
		
    }
}
