namespace DotNetCoreBoilerplate.Common.Notification
{
    public class Notification
    {

        public long Id { get; set; }
        public string SentByUserName { get; set; }
        public string SentByUserDetails { get; set; }
        public string ContentURL { get; set; }
        public string AvatarURL { get; set; }
        public string SenttoUserName { get; set; }
        public string NotificationText { get; set; }
        public bool IsRead { get; set; }
        public string TimeEnd { get; set; }
        public string TimeStart { get; set; }

    }
}
