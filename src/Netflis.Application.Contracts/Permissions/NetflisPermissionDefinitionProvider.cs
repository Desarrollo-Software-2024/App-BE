using Netflis.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Netflis.Permissions;

public class NetflisPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NetflisPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(NetflisPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NetflisResource>(name);
    }
}
