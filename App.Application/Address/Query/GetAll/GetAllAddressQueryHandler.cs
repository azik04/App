using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Query.GetAll;

public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, GenericResponse<List<GetAllAddressDto>>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;
    
    public GetAllAddressQueryHandler(IGenericRepository<Addresses> addressRepository, IAccountService accountService,
        IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository)
    {
        _accountService = accountService;
        _clientRepository = clientRepository;
        _workerRepository = workerRepository;
        _addressRepository = addressRepository;
    }

    public async Task<GenericResponse<List<GetAllAddressDto>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetById(request.appId);
        if (account == null)
            throw new Exception("Account not found");
        
        var data = new List<GetAllAddressDto>();

        if (account.Data.ClientId != null)
        {
            data = _addressRepository.Where(x => x.ClientId == account.Data.ClientId).Select(item => new GetAllAddressDto
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address
            }).ToList();
        }

        if (account.Data.WorkerId != null)
        {
            data = _addressRepository.Where(x => x.WorkerId == account.Data.WorkerId).Select(item => new GetAllAddressDto
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address
            }).ToList();
            
        }

        return GenericResponse<List<GetAllAddressDto>>.Ok(data);
    }
}