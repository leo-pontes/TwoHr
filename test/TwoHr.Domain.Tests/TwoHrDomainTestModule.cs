using TwoHr.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TwoHr;

[DependsOn(
    typeof(TwoHrEntityFrameworkCoreTestModule)
    )]
public class TwoHrDomainTestModule : AbpModule
{

}
