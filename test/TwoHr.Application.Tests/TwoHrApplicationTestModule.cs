using Volo.Abp.Modularity;

namespace TwoHr;

[DependsOn(
    typeof(TwoHrApplicationModule),
    typeof(TwoHrDomainTestModule)
    )]
public class TwoHrApplicationTestModule : AbpModule
{

}
