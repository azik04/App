using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;

namespace App.Domain.Entities.Main;

public class Payments
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public int Price { get; set; }
    public DateTime CreateAt { get; set; }
    public string Check { get; set; }
    public List<Subscriptions> Subscription { get; set; }
}
