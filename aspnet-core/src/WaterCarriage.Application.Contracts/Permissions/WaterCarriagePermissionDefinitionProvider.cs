using WaterCarriage.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WaterCarriage.Permissions;

/// <summary>
/// 定义权限组
/// </summary>
public class WaterCarriagePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(WaterCarriagePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WaterCarriagePermissions.MyPermission1, L("Permission:MyPermission1"));

        var waterCarriageGrroup = context.AddGroup(WaterCarriagePermissions.GroupName,L("Permission:WaterCarriage"));

        // 航道权限
        var channelPermission = waterCarriageGrroup.AddPermission(WaterCarriagePermissions.Channels.Default, L("Permission:Channels"));
        channelPermission.AddChild(WaterCarriagePermissions.Channels.Create, L("Permission:Channels.Create"));
        channelPermission.AddChild(WaterCarriagePermissions.Channels.Edit, L("Permission:Channels.Edit"));
        channelPermission.AddChild(WaterCarriagePermissions.Channels.Delete, L("Permission:Channels.Delete"));

        // 需求权限
        var requirementPermission = waterCarriageGrroup.AddPermission(WaterCarriagePermissions.Requirements.Default, L("Permission:Requirements"));
        requirementPermission.AddChild(WaterCarriagePermissions.Requirements.Create, L("Permission:Requirements.Create"));
        requirementPermission.AddChild(WaterCarriagePermissions.Requirements.Edit, L("Permission:Requirements.Edit"));
        requirementPermission.AddChild(WaterCarriagePermissions.Requirements.Delete, L("Permission:Requirements.Delete"));

        // 会员权限
        var memberPermission = waterCarriageGrroup.AddPermission(WaterCarriagePermissions.Members.Default, L("Permission:Members"));
        memberPermission.AddChild(WaterCarriagePermissions.Members.Create, L("Permission:Members.Create"));
        memberPermission.AddChild(WaterCarriagePermissions.Members.Edit, L("Permission:Members.Edit"));
        memberPermission.AddChild(WaterCarriagePermissions.Members.Delete, L("Permission:Members.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WaterCarriageResource>(name);
    }
}
