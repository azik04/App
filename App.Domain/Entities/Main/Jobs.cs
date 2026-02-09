using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Domain.Entities.Main;

public class Jobs
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid ClientId { get; set; }
    public Clients Client { get; set; }
    public Guid? WorkerId { get; set; }
    public Workers? Worker { get; set; }
    public bool isHandled { get; set; }
    public int ServiceId { get; set; } 
    public Services Service { get; set; }
    public int StatusId { get; set; }
    public Statuses Statuse { get; set; }
    public bool isActive { get; set; } 
    public List<JobFiles> JobFile { get; set; } 
}
