using Microsoft.AspNetCore.SignalR;
using PlayWithSignalR.API.SignalR.HubClients;

namespace PlayWithSignalR.API.SignalR.SocketHubs
{
    public class ChatHub : Hub<IChatHubClient>
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.RecieveMessage(user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.RecieveMessage("NotifyStream", $"{Context.ConnectionId} joined.");
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            await Clients.All.RecieveMessage("NotifyStream", $"{Context.ConnectionId} left.");
        }
    }
}
