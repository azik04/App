using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Create;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, GenericResponse<bool>>
{
    private readonly IAddressService _addressService;
    public CreateAddressCommandHandler(IAddressService addressService) => _addressService = addressService;
    
    
    public async Task<GenericResponse<bool>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        return await _addressService.CreateAsync(request.dto);
    }
}
