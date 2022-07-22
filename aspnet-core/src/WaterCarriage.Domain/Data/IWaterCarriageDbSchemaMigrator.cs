using System.Threading.Tasks;

namespace WaterCarriage.Data;

public interface IWaterCarriageDbSchemaMigrator
{
    Task MigrateAsync();
}
