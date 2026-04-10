using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Account;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Query.GetById;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GenericResponse<GetByIdAddressDto>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    private readonly IAccountService _accountService;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public GetByIdAddressQueryHandler(IGenericRepository<Addresses> addressRepository, IAccountService accountService,
        IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository)
    {
        _accountService = accountService;
        _clientRepository = clientRepository;
        _workerRepository = workerRepository;
        _addressRepository = addressRepository;
    }


    public async Task<GenericResponse<GetByIdAddressDto>> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var data = await _addressRepository.GetByIdAsync(request.id);
        if (data == null)
            return GenericResponse<GetByIdAddressDto>.Ok(null);

        var dto = new GetByIdAddressDto()
        {
            Address = data.Address,
            Id = data.Id,
            Name = data.Name,
            X = data.X,
            Y = data.Y
        };

        return GenericResponse<GetByIdAddressDto>.Ok(dto);
    }
}