using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Domain.Entities;

namespace Niue.Core.Entities.Cities
{
    [Description("城市")]
    public class City : Entity
    {
        [Required]
        [StringLength(32)]
        [Description("名称")]
        public virtual string Name { get; set; }

        [StringLength(100)]
        [Description("拼音全拼")]
        public virtual string SpellAll { get; set; }

        [StringLength(32)]
        [Description("拼音简写")]
        public virtual string SpellShort { get; set; }

        [StringLength(10)]
        [Description("首字母（大写）")]
        public virtual string Initial { get; set; }

        [Description("所属省份")]
        public virtual City Province { get; set; }

        [StringLength(10)]
        [Description("高德API城市代码（区号）")]
        public virtual string AmapCityCode { get; set; }

        [StringLength(10)]
        [Description("百度API城市代码")]
        public virtual string BaiduCityCode { get; set; }

        [StringLength(20)]
        [Description("市中心经度")]
        public virtual string Longitude { get; set; }

        [StringLength(20)]
        [Description("市中心纬度")]
        public virtual string Latitude { get; set; }

        [ConcurrencyCheck]
        [Description("学校安全编号")]
        public virtual int SchoolSecurityCode { get; set; }
    }
}
