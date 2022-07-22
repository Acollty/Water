using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace WaterCarriage;

[Dependency(ReplaceServices = true)]
public class WaterCarriageBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "WaterCarriage";
}
