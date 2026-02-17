using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Query.GetById;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GenericResponse<GetByIdAddressDto>>
{
    private readonly IAddressService _addressService;
    public GetByIdAddressQueryHandler(IAddressService addressService) => _addressService = addressService;


    public async Task<GenericResponse<GetByIdAddressDto>> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        return await _addressService.GetByIdAsync(request.id);
    }
}