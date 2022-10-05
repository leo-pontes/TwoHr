using TwoHr.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TwoHr.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TwoHrPageModel : AbpPageModel
{
    protected TwoHrPageModel()
    {
        LocalizationResourceType = typeof(TwoHrResource);
    }
}
