using System;

namespace DotNetCoreBoilerplate.Common.Notification
{
    public class GroupNotifications
    {
        public float Id { get; set; }
        public string SentByUserName { get; set; }
        public string SenttoUserName { get; set; }
        public bool IsRead { get; set; }
        public DateTime? TimeEnd { get; set; }
        public DateTime? TimeStart { get; set; }

    }
}
