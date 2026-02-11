using App.Domain.Entities.Main;

namespace App.Domain.Entities.List;

public class SmsTypes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Sms> Sms { get; set; }
}
