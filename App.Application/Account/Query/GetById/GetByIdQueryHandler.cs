using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Account.Query.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GenericResponse<GetByIdAccount>>
{
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public GetByIdQueryHandler(IAccountService accountService, IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository)
    {
        _accountService = accountService;
        _clientRepository = clientRepository;
        _workerRepository = workerRepository;
    }

    public async Task<GenericResponse<GetByIdAccount>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetById(request.id);

        if (account.Data == null)
            return GenericResponse<GetByIdAccount>.Fail("User not found");

        GetByIdAccount dto = null;

        if (account.Data.ClientId != null)
        {
            var client = await _clientRepository.GetByIdAsync(account.Data.ClientId);
            dto = new GetByIdAccount
            {
                Id = account.Data.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = account.Data.Email,
                PhoneNumber = client.PhoneNumber,
                FilePath = client.FilePath,
                ClientId = account.Data.ClientId
            };
        }

        if (account.Data.WorkerId != null)
        {
            var worker = await _workerRepository.GetByIdAsync(
                account.Data.WorkerId, 
                q => q.Include(w => w.WorkerJob)
            );
            
            dto = new GetByIdAccount
            {
                Id = account.Data.Id,
                Name = worker.Name,
                Surname = worker.Surname,
                Email = account.Data.Email,
                PhoneNumber = worker.PhoneNumber,
                FilePath = worker.FilePath,
                WorkerId = account.Data.ClientId,
                DeniedCount = worker.WorkerJob.Count(wj => wj.Status == Domain.Enums.WorkerJobStatus.Canceled),
                CompletedCount = worker.WorkerJob.Count(wj => wj.Status == Domain.Enums.WorkerJobStatus.Completed),
            };
        }
        return GenericResponse<GetByIdAccount>.Ok(dto);
    }
}
