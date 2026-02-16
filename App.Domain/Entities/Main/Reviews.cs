using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;

namespace App.Domain.Entities.Main;

public class Reviews
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ClientId { get; set; }
    public Clients Client { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Worker { get; set; }
    public int Stars { get; set; }
    public List<ReviewFiles> ReviewFile { get; set; }
}
