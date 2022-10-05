using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TwoHr.Data;

/* This is used if database provider does't define
 * ITwoHrDbSchemaMigrator implementation.
 */
public class NullTwoHrDbSchemaMigrator : ITwoHrDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
