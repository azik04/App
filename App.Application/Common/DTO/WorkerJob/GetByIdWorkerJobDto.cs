using App.Domain.Enums;

namespace App.Application.Common.DTO.WorkerJob;

public class GetByIdWorkerJobDto
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public string WorkerName { get; set; }

    public Guid JobId { get; set; }
    public string Status { get; set; }
    public string CreateAt { get; set; }
    public string? FinishAt { get; set; }
}
