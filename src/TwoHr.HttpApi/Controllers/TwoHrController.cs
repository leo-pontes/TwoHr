using TwoHr.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TwoHr.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TwoHrController : AbpControllerBase
{
    protected TwoHrController()
    {
        LocalizationResource = typeof(TwoHrResource);
    }
}
