using App.Domain.Entities.Acc;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using App.Domain.Enums;

namespace App.Domain.Entities.History;

public class WorkerJobHistories
{
    public long Id { get; set; }
    public Guid WorkerJobId { get; set; }
    public WorkerJobs WorkerJob { get; set; }
    public Guid WorkerId { get; set; }
    public Workers Workers { get; set; }
    public Guid JobId { get; set; }
    public Jobs Jobs { get; set; }
    public WorkerJobStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? FinishAt { get; set; }
}
