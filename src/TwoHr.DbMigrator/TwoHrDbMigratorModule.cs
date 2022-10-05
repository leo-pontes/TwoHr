using TwoHr.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TwoHr.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TwoHrEntityFrameworkCoreModule),
    typeof(TwoHrApplicationContractsModule)
    )]
public class TwoHrDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
