using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Address.Query.GetAll;

public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, GenericResponse<List<GetAllAddressDto>>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    private readonly IAccountService _accountService;
    
    public GetAllAddressQueryHandler(IGenericRepository<Addresses> addressRepository, IAccountService accountService)
    {
        _accountService = accountService;
        _addressRepository = addressRepository;
    }

    public async Task<GenericResponse<List<GetAllAddressDto>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetById(request.appId);
        if (account.Data == null)
            return GenericResponse<List<GetAllAddressDto>>.Fail("Account not found");
        
        var data = new List<GetAllAddressDto>();

        if (account.Data.ClientId != null)
        {
            data = await _addressRepository.Where(x => x.ClientId == account.Data.ClientId).Select(item => new GetAllAddressDto
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address
            }).ToListAsync(cancellationToken);
        }

        if (account.Data.WorkerId != null)
        {
            data = await _addressRepository.Where(x => x.WorkerId == account.Data.WorkerId).Select(item => new GetAllAddressDto
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address
            }).ToListAsync(cancellationToken);
        }

        return GenericResponse<List<GetAllAddressDto>>.Ok(data);
    }
}