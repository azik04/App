using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;

namespace App.Domain.Entities.Main;

public class Subscriptions
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public Guid PaymentId { get; set; }
    public Payments Payments { get; set; }
    public DateOnly StartAt { get; set; }
    public DateOnly EndAt { get; set; }
    public bool isActive { get; set; }
}
