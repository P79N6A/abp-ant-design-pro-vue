using System;
using System.Collections.Generic;
using System.Linq;

namespace Niue.Application.BaseDto
{
    /// <summary>
    /// 分页DTO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PaginationDto<T> : SortDto
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 单页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }

        public PaginationDto()
        {
            PageNo = 1;
            PageSize = 10;
            TotalCount = 0;
            Data = new List<T>();
        }
    }

    /// <summary>
    /// 分页扩展
    /// </summary>
    public static class PaginationExtensions
    {
        /// <summary>
        /// 将List&#60;T&#62;转成分页DTO
        /// <code>List&#60;T&#62; list = new List&#60;T&#62;();
        /// PaginationDto&#60;T&#62; paginationDto = list.ToPagination(PaginationDto&#60;T&#62; paginationDto);</code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="paginationDto"></param>
        /// <returns></returns>
        public static PaginationDto<T> ToPagination<T>(this List<T> list, PaginationDto<T> paginationDto = null)
        {
            if (paginationDto == null)
            {
                paginationDto = new PaginationDto<T>();
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(paginationDto.SortField))
                {
                    IQueryable<T> queryable = list.AsQueryable();
                    if (!string.IsNullOrWhiteSpace(paginationDto.SortOrder) && paginationDto.SortOrder == "descend")
                    {
                        list = queryable.OrderByDescending(paginationDto.SortField).ToList();
                    }
                    else
                    {
                        list = queryable.OrderBy(paginationDto.SortField).ToList();
                    }
                }
            }
            catch (Exception)
            {
                //ignore
            }
            paginationDto.TotalCount = list.Count;
            paginationDto.Data = list;
            if (list.Count == 0)
            {
                paginationDto.Data = list;
                return paginationDto;
            }
            if (paginationDto.PageSize <= 0)
            {
                paginationDto.Data = list;
                return paginationDto;
            }
            var pageCount = paginationDto.TotalCount / paginationDto.PageSize + 1;
            if (paginationDto.PageNo > pageCount)
            {
                paginationDto.Data = list.FindAll(o => false);
                return paginationDto;
            }
            if (paginationDto.PageNo == pageCount)
            {
                paginationDto.Data = list.GetRange(paginationDto.PageSize * (paginationDto.PageNo - 1), list.Count - paginationDto.PageSize * (paginationDto.PageNo - 1));
                return paginationDto;
            }
            paginationDto.Data = list.GetRange(paginationDto.PageSize * (paginationDto.PageNo - 1), paginationDto.PageSize);
            return paginationDto;
        }
    }
}
