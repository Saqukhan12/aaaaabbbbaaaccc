using Microsoft.AspNetCore.SignalR;

namespace DotNetCoreBoilerplate.Common
{
    public class SignalRUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Identity.Name;
        }
    }
}