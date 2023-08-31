

using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBoilerplate.Common
{
    public class AuditTb
    {
        [Key]
        public Guid UsersAuditId { get; set; }
        public string UserId { get; set; }
        public string IpAddress { get; set; }
        public string PageAccessed { get; set; }
        //Time now
        public DateTime? LoggedInAt { get; set; }
        //Operation
        public string Method { get; set; }
    }
}
