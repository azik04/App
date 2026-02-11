using App.Domain.Entities.Main;

namespace App.Domain.Entities.Acc;

public class Clients
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Jobs> Job { get; set; }
    public List<Reviews> Review { get; set; }
    public List<Sms> Sms { get; set; }
}
