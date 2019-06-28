using System;
using System.Collections.Generic;
using System.ComponentModel;
using Niue.Abp.Abp.Application.Services.Dto;

namespace Niue.Application.Routers.Dto
{
    /// <summary>
    /// 路由
    /// </summary>
    [Serializable]
    public class RouterDto : EntityDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 该路由对应页面的组件
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 路由Key，建议唯一
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 重定向
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// 路由名称，建议唯一
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<RouterDto> Children { get; set; }
    }
}
