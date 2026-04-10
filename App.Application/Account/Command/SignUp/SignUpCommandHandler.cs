using App.Application.Common.DTO.Account;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, GenericResponse<bool>>
{
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public SignUpCommandHandler(IAccountService accountService, IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository)
    {
        _clientRepository = clientRepository;
        _accountService = accountService;
        _workerRepository = workerRepository;
    }


    public async Task<GenericResponse<bool>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        if (request.Role == 1)
        {
            var client = new Clients
            {
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                FilePath = "/Static/profile.png"
            };
            await _clientRepository.InsertAsync(client);

            var user = await _accountService.SignUpAsync(request, null, client.Id);
        }

        if (request.Role == 2)
        {
            var worker = new Workers
            {
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Pin = request.Pin,
                FilePath = "/Static/profile.png"
            };
            await _workerRepository.InsertAsync(worker);

            var user = await _accountService.SignUpAsync(request, worker.Id, null);
        }

        return GenericResponse<bool>.Ok(true);
    }
}