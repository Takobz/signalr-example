using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalr_example.Data.Entities;
using SignalRExample.Data;
using SignalRExample.Hubs;

namespace signalr_example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<DatabaseHub, IDatabaseHubEvents> _dbHubContext;
        private readonly ISignalRDbContext _signalRDbContext;

        public SignalRController(
            IHubContext<DatabaseHub, IDatabaseHubEvents> dbHubContext,
            ISignalRDbContext signalRDbContext)
        {
            //make sure you have registerd IDatabaseHubEvents in the DI container
            //i.e services.AddSingleton<IDatabaseHubEvents, DatabaseHub>()
            _dbHubContext = dbHubContext;
            _signalRDbContext = signalRDbContext;
        }

        [Route("add-person")]
        [HttpPost]
        public async Task<IActionResult> AddPerson(string name, string surname)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                return BadRequest("user must have name and surname");

            var person = new Person
            {
                Name = name,
                Surname = surname,
                UserName = $"{Guid.NewGuid()}"
            };

            DatabaseResult<Person> result = _signalRDbContext.AddPerson(person);
            if (result.Status == Status.Success)
            {
                var changeModel = new TableChangeModel
                {
                    TableName = "Person",
                    ItemId = result.Data.Id
                };

                //Calling all clients and giving them the change model.
                await _dbHubContext.Clients.All.ProductTableChanged(changeModel);
                return Ok("User Added and alerted subscribers!");
            }

            //generates appropriate response based on database result
            return Conflict();
        }
    }
}