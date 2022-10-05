using System.Threading.Tasks;

namespace TwoHr.Data;

public interface ITwoHrDbSchemaMigrator
{
    Task MigrateAsync();
}
