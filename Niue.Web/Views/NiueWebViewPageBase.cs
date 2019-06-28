using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Views;
using Niue.Core;

namespace Niue.Web.Views
{
    public abstract class NiueWebViewPageBase : NiueWebViewPageBase<dynamic>
    {

    }

    public abstract class NiueWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected NiueWebViewPageBase()
        {
            LocalizationSourceName = NiueConsts.LocalizationSourceName;
        }
    }
}