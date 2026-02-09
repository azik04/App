using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Domain.Entities.Rel;

public class WorkerServices
{
    public int Id { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public int ServiceId { get; set; }
    public Services Service { get; set; }
}
