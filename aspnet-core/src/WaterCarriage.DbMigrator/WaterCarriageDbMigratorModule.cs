using WaterCarriage.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using WaterCarriage.Data;

namespace WaterCarriage.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WaterCarriageEntityFrameworkCoreModule),
    typeof(WaterCarriageApplicationContractsModule)
    )]
public class WaterCarriageDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);

        // Remove the contributor for migrator module
        // context.Services.RemoveAll(t => t.ImplementationType == typeof(IDataSeedContributor));

        // Add custom data seed contributor
        // context.Services.AddTransient<IDataSeedContributor, ChannelDataSeederContributor>();
        // context.Services.AddTransient<IDataSeedContributor, RequirementDataSeederContributor>();
        // context.Services.AddTransient<IDataSeedContributor, MemberDataSeederContributor>();
    }
}
