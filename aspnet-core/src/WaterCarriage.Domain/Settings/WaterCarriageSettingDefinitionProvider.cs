using Volo.Abp.Settings;

namespace WaterCarriage.Settings;

public class WaterCarriageSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WaterCarriageSettings.MySetting1));
    }
}
