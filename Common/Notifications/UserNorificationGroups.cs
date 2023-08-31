using DotNetCoreBoilerplate.Identity.Models;

namespace DotNetCoreBoilerplate.Common.Notification
{
    public class UserNorificationGroups
    {
        public uint Id { get; set; }
        public string Description { get; set; }
        public virtual UserDefinGroup UserDefinGroup { get; set; }
        public string UserDefinGroupId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
