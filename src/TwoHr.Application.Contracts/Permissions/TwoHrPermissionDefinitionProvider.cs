using TwoHr.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TwoHr.Permissions;

public class TwoHrPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var hrGroup = context.AddGroup(TwoHrPermissions.GroupName, L("Permission:TwoHr"));
        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TwoHrPermissions.MyPermission1, L("Permission:MyPermission1"));

        var employeesPermission = hrGroup.AddPermission(TwoHrPermissions.Employees.Default, L("Permission:Employees"));
        employeesPermission.AddChild(TwoHrPermissions.Employees.Create, L("Permission:Employees.Create"));
        employeesPermission.AddChild(TwoHrPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        employeesPermission.AddChild(TwoHrPermissions.Employees.Delete, L("Permission:Employees.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TwoHrResource>(name);
    }
}
