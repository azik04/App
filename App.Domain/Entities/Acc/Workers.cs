using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;

namespace App.Domain.Entities.Acc;

public class Workers
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public decimal Rating { get; private set; } = 0;
    public string? FilePath { get; private set; }
    public List<Jobs> Job { get; set; }
    public List<Reviews> Review { get; set; }
    public List<Payments> Payment { get; set; }
    public List<Subscriptions> Subscription { get; set; }
    public List<WorkerServices> WorkerService { get; set; }
    public List<Sms> Sms { get; set; }
}
