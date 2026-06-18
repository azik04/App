using App.Domain.Enums;

namespace App.Application.Common.DTO.WorkerJobHistory;

public class GetAllWorkerJobHistoryDto
{
    public long Id { get; set; }
    public Guid WorkerId { get; set; }
    public string WorkerName { get; set; }
    public WorkerJobStatus Status { get; set; }
    public string CreateAt { get; set; }
    public string? FinishAt { get; set; }
}
