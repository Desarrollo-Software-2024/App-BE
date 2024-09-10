using Volo.Abp.Settings;

namespace Netflis.Settings;

public class NetflisSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NetflisSettings.MySetting1));
    }
}
