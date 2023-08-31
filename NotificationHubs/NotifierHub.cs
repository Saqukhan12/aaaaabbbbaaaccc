using Microsoft.AspNetCore.SignalR;
using System;
using System.Globalization;
using System.Threading.Tasks;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Identity.ViewModels;

namespace DotNetCoreBoilerplate.NotificationHubs
{

    public class NotifierHub : Hub, INotifierHub
    {

        private ApplicationUserVM applicatonUser;
        public NotifierHub(IUserSessionService userSessionService)
        {
            applicatonUser = userSessionService.GetCurrentUser();
        }

        public async Task SendMessage(string sentByUserName, string message, string ToUser, string sentByUserDetails, string contentURL, string avatarurl)
        {
            string timestart = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("es-ES"));
            await Clients.User(ToUser).SendAsync("ReceiveMessage", message, timestart, sentByUserName, avatarurl, sentByUserDetails, contentURL);
        }


        //public async Task SendMessage(string CurrentUser, string message)
        //{
        //    string sentuser = Context.User.Identity.Name;
        //    string avatarurl = applicatonUser.AvatarURL;
        //    string timestart = DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("es-ES"));
        //    await Clients.User(user).SendAsync("ReceiveMessage",  message, timestart, sentuser, avatarurl);
        //}

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.User(user).SendAsync("ReceiveMessage", message);
        //}

        public override Task OnConnectedAsync()
        {
            base.OnConnectedAsync();
            var user = Context.User.Identity.Name;
            //Groups.AddAsync(Context.ConnectionId, user);

            return Task.CompletedTask;
        }



    }
}
