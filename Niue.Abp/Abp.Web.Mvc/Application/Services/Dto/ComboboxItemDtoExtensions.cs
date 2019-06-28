using System.Web.Mvc;
using Niue.Abp.Abp.Application.Services.Dto;

namespace Niue.Abp.Abp.Web.Mvc.Application.Services.Dto
{
    public static class ComboboxItemDtoExtensions
    {
        public static SelectListItem ToSelectListItem(this ComboboxItemDto comboboxItem)
        {
            return new SelectListItem
            {
                Value = comboboxItem.Value,
                Text = comboboxItem.DisplayText,
                Selected = comboboxItem.IsSelected
            };
        }
    }
}
