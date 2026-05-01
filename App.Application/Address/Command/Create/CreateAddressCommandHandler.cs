using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Command.Create;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public CreateAddressCommandHandler(IGenericRepository<Addresses> addressRepository, IAccountService accountService, 
        IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository) 
    {
        _accountService = accountService;
        _clientRepository = clientRepository;
        _workerRepository = workerRepository;
        _addressRepository = addressRepository; 
    }

    public async Task<GenericResponse<bool>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetById(request.AppId);

        if (account.Data.ClientId != null)
        {
            var client = await _clientRepository.GetByIdAsync(account.Data.ClientId);

            var data = new Addresses()
            {
                Address = request.Address,
                ClientId = client.Id,
                Name = request.Name,
                Lat = request.Lat,
                Lng = request.Lng
            };
            await _addressRepository.InsertAsync(data);
        }

        if (account.Data.WorkerId != null)
        {
            var worker = await _workerRepository.GetByIdAsync(account.Data.WorkerId);

            var data = new Addresses()
            {
                Address = request.Address,
                WorkerId = worker.Id,
                Name = request.Name,
                Lat = request.Lat,
                Lng = request.Lng
            };
            await _addressRepository.InsertAsync(data);
        } 
        
        return GenericResponse<bool>.Ok(true);
    }
}
