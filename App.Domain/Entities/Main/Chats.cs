using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities.Main;

public class Chats
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SenderId { get; set; } 
    public Guid RecieverId { get; set; } 
    public string Message { get; set; }
    public DateTime SentAt { get; set; } = DateTime.Now;
}
