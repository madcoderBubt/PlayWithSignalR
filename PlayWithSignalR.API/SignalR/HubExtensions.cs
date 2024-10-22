using PlayWithSignalR.API.SignalR.SocketHubs;

namespace PlayWithSignalR.API.SignalR
{
    public static class HubExtensions
    {
        public static IEndpointRouteBuilder MapSignalrHubs(this IEndpointRouteBuilder app)
        {
            app.MapHub<TodoHub>("/Todo");
            app.MapHub<ChatHub>("/Chat");

            return app;
        }
    }
}
