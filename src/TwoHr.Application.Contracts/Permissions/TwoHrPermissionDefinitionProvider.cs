using TwoHr.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TwoHr.Permissions;

public class TwoHrPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TwoHrPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TwoHrPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TwoHrResource>(name);
    }
}
