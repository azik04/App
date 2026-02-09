using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;

namespace App.Domain.Entities.List;

public class Services
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Jobs> Job { get; set; }
    public List<WorkerServices> WorkerService { get; set; }
}
