using System;
using System.ComponentModel;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Core.Enums;

namespace Niue.Application.BaseDto
{
    /// <summary>
    /// 返回结果DTO
    /// </summary>
    [Serializable]
    public class ResultDto
    {
        /// <summary>
        /// 返回代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public ResultDto()
        {
            Code = 0;
            Message = EnumResultCode.Success.ToMessage();
            Data = null;
        }

        public ResultDto(EnumResultCode code)
        {
            Code = (int) code;
            Message = code.ToMessage();
            Data = null;
        }

        public ResultDto(EnumResultCode code, object data)
        {
            Code = (int) code;
            Message = code.ToMessage();
            Data = data;
        }
    }

    public class ResultDto<T> : ResultDto
    {
        public ResultDto(EnumResultCode code, object data)
        {
            Code = (int) code;
            Message = code.ToMessage();
            Data = data.MapTo<T>();
        }
    }

    public static class ResultExtensions
    {
        /// <summary>
        /// 将返回代码转化为消息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ToMessage(this EnumResultCode code)
        {
            var type = code.GetType(); //获取类型
            var memberInfos = type.GetMember(code.ToString()); //获取成员
            if (memberInfos.Length > 0)
            {
                var attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[]; //获取描述特性
                if (attrs != null && attrs.Length > 0)
                {
                    return attrs[0].Description; //返回当前描述
                }
            }
            return "未知错误";
        }

        /// <summary>
        /// 将返回代码转化为ResultDto
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ResultDto ToResultDto(this EnumResultCode code)
        {
            return new ResultDto(code);
        }

        /// <summary>
        /// 将object自动转化为ResultDto
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ResultDto ResultTo(this object data, EnumResultCode code = EnumResultCode.Success)
        {
            return new ResultDto(code, data);
        }

        /// <summary>
        /// 将object自动转化为ResultDto
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ResultDto ResultTo<T>(this object data, EnumResultCode code = EnumResultCode.Success)
        {
            return new ResultDto<T>(code, data);
        }
    }
}
