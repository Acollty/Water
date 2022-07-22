using WaterCarriage.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WaterCarriage;

[DependsOn(
    typeof(WaterCarriageEntityFrameworkCoreTestModule)
    )]
public class WaterCarriageDomainTestModule : AbpModule
{

}
