using System.Threading.Tasks;

namespace DotNetCoreBoilerplate.NotificationHubs
{
    public interface INotifierHub
    {

        Task SendMessage(string SentByUserName, string message, string ToUser, string sentByUserDetails, string contentURL, string avatarurl);
    }
}
