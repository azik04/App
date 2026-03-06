using App.Infrastructure.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatTest : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;

        public ChatTest(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public async Task Send(string userId, string message)
        {
            await _hub.Clients.User(userId)
                .SendAsync("ReceiveMessage", message);
        }
    }
}
