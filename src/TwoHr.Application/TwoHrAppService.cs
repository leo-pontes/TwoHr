using System;
using System.Collections.Generic;
using System.Text;
using TwoHr.Localization;
using Volo.Abp.Application.Services;

namespace TwoHr;

/* Inherit your application services from this class.
 */
public abstract class TwoHrAppService : ApplicationService
{
    protected TwoHrAppService()
    {
        LocalizationResource = typeof(TwoHrResource);
    }
}
