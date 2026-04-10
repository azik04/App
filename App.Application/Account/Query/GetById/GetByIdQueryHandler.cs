using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Account.Query.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GenericResponse<GetByIdAccount>>
{
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientService;
    private readonly IGenericRepository<Workers> _workerService;

    public GetByIdQueryHandler(IAccountService accountService, IGenericRepository<Clients> clientService, IGenericRepository<Workers> workerService)
    {
        _accountService = accountService;
        _clientService = clientService;
        _workerService = workerService;
    }

    public async Task<GenericResponse<GetByIdAccount>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetById(request.id);

        GetByIdAccount dto = null;

        if (account.ClientId != null)
        {
            var client = await _clientService.GetByIdAsync(account.ClientId);
            dto = new GetByIdAccount
            {
                Id = account.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = account.Email,
                PhoneNumber = client.PhoneNumber,
                FilePath = client.FilePath,
                ClientId = account.ClientId
            };
        }

        if (account.WorkerId != null)
        {
            var client = await _workerService.GetByIdAsync(account.WorkerId);
            dto = new GetByIdAccount
            {
                Id = account.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = account.Email,
                PhoneNumber = client.PhoneNumber,
                FilePath = client.FilePath,
                ClientId = account.ClientId
            };
        }
        return GenericResponse<GetByIdAccount>.Ok(dto);
    }
}
