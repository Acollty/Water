namespace WaterCarriage.Permissions;

/// <summary>
/// 定义权限名称
/// </summary>
public static class WaterCarriagePermissions
{
    public const string GroupName = "WaterCarriage";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Channels 
    {
        public const string Default = GroupName + ".Channels";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Requirements {
        public const string Default = GroupName + ".Requirements";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Members
    {
        public const string Default = GroupName + ".Members";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
