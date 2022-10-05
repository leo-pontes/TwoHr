using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TwoHr.Web;

[Dependency(ReplaceServices = true)]
public class TwoHrBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TwoHr";
}
