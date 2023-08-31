namespace DotNetCoreBoilerplate.Common.Notification
{
    public class UserDefinGroup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public virtual SystemDefineGroup SystemDefineGroup { get; set; }

    }
}
