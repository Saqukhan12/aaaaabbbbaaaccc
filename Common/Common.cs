namespace DotNetCoreBoilerplate.Common
{
    public class ReturnData
    {
        public dynamic Data { get; set; }
    }
    public class HandleMessage
    {
        public static string ErrorMessage = "Something went wrong. Please try again.";
        public bool Success = true;
        public bool Info { get; set; }
        public bool Warning { get; set; }
        public string MessageDetail = "Request processed successfully";

    }
    public static class Static
    {
        //public static string UserId { get { try { return HttpContext. } catch { return String.Empty; } } }
        //public static UserStaffAllocation UserProfile { get { return UserId.FetchUserProfile(); } }

    }
}
