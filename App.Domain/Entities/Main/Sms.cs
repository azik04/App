using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Domain.Entities.Main;

public class Sms
{
    public int Id { get; set; }
    public Guid? ClientId {  get; set; }
    public Clients? Client { get; set; }
    public Guid? WorkerId { get; set; }
    public Workers? Worker { get; set; }
    public int SmsTypeId { get; set; }
    public SmsTypes SmsType { get; set; }
}
