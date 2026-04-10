using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.File;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Account.Command.Update;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, GenericResponse<bool>>
{
    private readonly IAppFileService _appFileService;
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public UpdateAccountCommandHandler(IAccountService accountService, IGenericRepository<Workers> workerRepository, IGenericRepository<Clients> clientRepository, IAppFileService appFileService)
    {
        _workerRepository = workerRepository;
        _appFileService = appFileService;
        _accountService = accountService;
        _clientRepository = clientRepository;
    }


    public async Task<GenericResponse<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await _accountService.GetById(request.id);
        if (user == null)
            return GenericResponse<bool>.Fail("User not found");

        var files = new List<IFormFile> { request.file };
        var filePath = await _appFileService.CreateAsync(files, Domain.Enums.FileTypes.Profile);

        if (user.ClientId != null)
        {
            var client = await _clientRepository.GetByIdAsync(user.ClientId);
            if (client.FilePath != null)
            {
                _appFileService.Delete(client.FilePath);
            }

            client.Name = request.name;
            client.Surname = request.surname;
            client.PhoneNumber = request.phoneNumber;
            client.FilePath = filePath.Data[0]; 

            await _clientRepository.Update(client);
        }

        if (user.WorkerId != null)
        {
            var worker = await _workerRepository.GetByIdAsync(user.WorkerId);

            worker.Name = request.name;
            worker.Surname = request.surname;
            worker.PhoneNumber = request.phoneNumber;
            worker.FilePath = filePath.Data[0];

            await _workerRepository.Update(worker);
        }

        return GenericResponse<bool>.Ok(true);
    }
}
