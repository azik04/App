using App.Domain.Entities.Main;
using App.Infrastructure.Context;
using Microsoft.AspNetCore.SignalR;

namespace App.Infrastructure.Hubs;

public class ChatHub : Hub
{
    private readonly AppDbContext _db;
    public ChatHub(AppDbContext db)
    {
        _db = db;
    }


    public async Task SendMessage(Guid receiverId, string message)
    {
        var senderId = Context.User?.FindFirst("sub")?.Value;
        if (senderId == null)
            return;

        var chat = new Chats
        {
            SenderId = Guid.Parse(senderId),
            RecieverId = receiverId,
            Message = message,
        };

        await _db.Chat.AddAsync(chat);
        await _db.SaveChangesAsync();

        await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", senderId, message);
    }
}
