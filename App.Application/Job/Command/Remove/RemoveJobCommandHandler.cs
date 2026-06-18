using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Remove;

public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    private readonly IAccountService _accountService;
    public RemoveJobCommandHandler(IGenericRepository<Jobs> jobRepository, IAccountService accountService)
    {
        _jobRepository = jobRepository;
        _accountService = accountService;
    }

    public async Task<GenericResponse<bool>> Handle(RemoveJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetByIdAsync(request.id, null, cancellationToken);
        if (job == null)
            return GenericResponse<bool>.Fail();

        var account = await _accountService.GetById(request.appId);
        if (account.Data.ClientId != job.ClientId)
            return GenericResponse<bool>.Fail("Wrong Client");
        
        _jobRepository.Delete(job, cancellationToken);

        return GenericResponse<bool>.Ok(true);
    }
}