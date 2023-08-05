using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs;

public class DatabaseHub : Hub<IDatabaseHubEvents>
{
    public async Task NotifyAll(TableChangeModel changeModel)
    {
        //I can cause an event in here by calling Clients property.
       //or something unrelated to SignalR.
       await Clients.All.ProductTableChanged(changeModel);
    }
}

public interface IDatabaseHubEvents
{
    //Event we are going to fire when Product table changes.
    Task ProductTableChanged(TableChangeModel changeModel);

    //Event we are going to fire when Person table changes.
    Task PersonTableChanged(PersonChangeModel changeModel);
}