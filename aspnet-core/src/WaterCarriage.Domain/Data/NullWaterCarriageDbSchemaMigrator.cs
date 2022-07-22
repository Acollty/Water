using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WaterCarriage.Data;

/* This is used if database provider does't define
 * IWaterCarriageDbSchemaMigrator implementation.
 */
public class NullWaterCarriageDbSchemaMigrator : IWaterCarriageDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
