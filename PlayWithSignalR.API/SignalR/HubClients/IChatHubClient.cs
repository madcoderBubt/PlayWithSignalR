namespace PlayWithSignalR.API.SignalR.HubClients
{
    public interface IChatHubClient
    {
        Task RecieveMessage(string user, string message);
    }
}
