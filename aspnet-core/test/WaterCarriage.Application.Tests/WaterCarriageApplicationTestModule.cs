using Volo.Abp.Modularity;

namespace WaterCarriage;

[DependsOn(
    typeof(WaterCarriageApplicationModule),
    typeof(WaterCarriageDomainTestModule)
    )]
public class WaterCarriageApplicationTestModule : AbpModule
{

}
