using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Query.GetAll;

public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, GenericResponse<List<GetAllAddressDto>>>
{
    private readonly IAddressService _addressService;
    public GetAllAddressQueryHandler(IAddressService addressService) => _addressService = addressService;


    public async Task<GenericResponse<List<GetAllAddressDto>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        return await _addressService.GetAllAsync(request.clientId);
    }
}