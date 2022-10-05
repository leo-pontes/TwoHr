using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwoHr.Data;
using Volo.Abp.DependencyInjection;

namespace TwoHr.EntityFrameworkCore;

public class EntityFrameworkCoreTwoHrDbSchemaMigrator
    : ITwoHrDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTwoHrDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the TwoHrDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TwoHrDbContext>()
            .Database
            .MigrateAsync();
    }
}
