using App.Infrastructure.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace App.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;

        public ChatController(IHubContext<ChatHub> hub) => _hub = hub;


        /// <summary>
        /// Sends a real-time message to a specific user through SignalR.
        /// </summary>
        /// <param name="userId">The identifier of the user who will receive the message.</param>
        /// <param name="message">The message content that will be sent to the user.</param>
        /// <returns>Returns a task representing the asynchronous send operation.</returns>
        [HttpPost("user/{userId}/messages")]
        public async Task Send(string userId, string message)
        {
            await _hub.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
    }
}
