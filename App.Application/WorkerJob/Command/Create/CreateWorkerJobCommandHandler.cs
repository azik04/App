using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.History;
using App.Domain.Entities.Main;
using App.Domain.Entities.Rel;
using App.Domain.Enums;
using MediatR;

namespace App.Application.WorkerJob.Command.Create;

public class CreateWorkerJobCommandHandler : IRequestHandler<CreateWorkerJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<WorkerJobs> _workerJobRepository;
    private readonly IGenericRepository<Workers> _workerRepository;
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IGenericRepository<WorkerJobHistories> _workerJobHistoryRepository;

    public CreateWorkerJobCommandHandler(IGenericRepository<WorkerJobs> workerJobRepository, 
        IGenericRepository<Jobs> jobRepository, IGenericRepository<Workers> workerRepository, 
        IGenericRepository<WorkerJobHistories> workerJobHistoryRepository, IAccountService accountService)
    {
        _accountService = accountService;
        _workerJobRepository = workerJobRepository;
        _jobRepository = jobRepository;
        _workerRepository = workerRepository;
        _workerJobHistoryRepository = workerJobHistoryRepository;
    }


    public async Task<GenericResponse<bool>> Handle(CreateWorkerJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetByIdAsync(request.JobId, null, cancellationToken);
        if (job == null)
            return GenericResponse<bool>.Fail("Job not found");

        if (job.Statuses == Statuses.Done)
            return GenericResponse<bool>.Fail("Jon has been done");
          
        var worker = await _workerRepository.GetByIdAsync(request.WorkerId, null, cancellationToken);
        if (worker == null) 
            return GenericResponse<bool>.Fail("Worker not found");

        var workerJob = _workerJobRepository.Where(x => x.WorkerId == request.WorkerId && x.JobId == request.JobId).FirstOrDefault();

        if (job.Statuses == Statuses.Active)
        {
            if (request.workerJobStatus != null)
                return GenericResponse<bool>.Fail("Cant be canceled or submited with out handling");

            var data = new WorkerJobs
            {
                JobId = request.JobId,
                WorkerId = request.WorkerId,
                Status = Domain.Enums.WorkerJobStatus.Owned,
                CreateAt = DateTime.Now,
            };

            await _workerJobRepository.InsertAsync(data, cancellationToken);

            var workerJobHistory = new WorkerJobHistories
            {
                WorkerJobId = data.Id,
                WorkerId = data.WorkerId,
                CreateAt = data.CreateAt,
                FinishAt = data.FinishAt,
                JobId = data.JobId,
                Status = data.Status,
            };

            await _workerJobHistoryRepository.InsertAsync(workerJobHistory, cancellationToken);

            job.Statuses = Statuses.IsHandled;

            await _jobRepository.Update(job, cancellationToken);

            return GenericResponse<bool>.Ok(true);
        }
        else if (job.Statuses == Statuses.IsHandled)
        {
            switch (request.workerJobStatus)
            {
                case WorkerJobStatus.Canceled:

                    workerJob.Status = Domain.Enums.WorkerJobStatus.Canceled;
                    workerJob.FinishAt = DateTime.Now;

                    await _workerJobRepository.Update(workerJob, cancellationToken);

                    await _workerJobHistoryRepository.InsertAsync(CreateHistory(workerJob), cancellationToken);

                    job.Statuses = Statuses.Active;

                    await _jobRepository.Update(job, cancellationToken);

                    break;

                case WorkerJobStatus.Completed:

                    workerJob.Status = WorkerJobStatus.Completed;
                    workerJob.FinishAt = DateTime.UtcNow;

                    await _workerJobRepository.Update(
                        workerJob,
                        cancellationToken);

                    await _workerJobHistoryRepository.InsertAsync(CreateHistory(workerJob), cancellationToken);

                    job.Statuses = Statuses.Done;

                    await _jobRepository.Update(
                        job,
                        cancellationToken);

                    break;

                default:
                    return GenericResponse<bool>.Fail("Invalid job status");
            }
            return GenericResponse<bool>.Ok(true);

        }
        else if (job.Statuses == Statuses.Done)
            return GenericResponse<bool>.Ok(true);

        return GenericResponse<bool>.Fail();

    }

    private static WorkerJobHistories CreateHistory(WorkerJobs workerJob)
    {
        return new WorkerJobHistories
        {
            WorkerJobId = workerJob.Id,
            WorkerId = workerJob.WorkerId,
            JobId = workerJob.JobId,
            CreateAt = workerJob.CreateAt,
            FinishAt = workerJob.FinishAt,
            Status = workerJob.Status
        };
    }
}
