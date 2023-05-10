using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs;

public class DatabaseHub : Hub<DatabaseHubMethods>
{
    public async Task DatabaseChange(string client)
    {
        await Clients.All.DatabaseChanged(client);
    }
}

public interface DatabaseHubMethods
{
    Task DatabaseChanged(string client);
}