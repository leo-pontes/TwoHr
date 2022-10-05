using Volo.Abp.Settings;

namespace TwoHr.Settings;

public class TwoHrSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TwoHrSettings.MySetting1));
    }
}
