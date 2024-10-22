using Microsoft.AspNetCore.SignalR;

namespace PlayWithSignalR.API.SignalR.SocketHubs
{
    public class TodoHub : Hub
    {
        private List<string> items= new List<string>();

        public async Task AddTodoItem(string name)
        {
            items.Add(name);
            await Clients.All.SendAsync("TodoItems", items);
        }
        public async Task DelTodoItem(string name)
        {
            items.Remove(name);
            await Clients.All.SendAsync("TodoItems", items);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("NotifyStream", $"{Context.ConnectionId} joined.");
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            await Clients.All.SendAsync("NotifyStream", $"{Context.ConnectionId} left.");
        }
    }
}
