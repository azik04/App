using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Update;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, GenericResponse<bool>>
{
    private readonly IAddressService _addressService;
    public UpdateAddressCommandHandler(IAddressService addressService) => _addressService = addressService;

    
    public async Task<GenericResponse<bool>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        return await _addressService.UpdateAsync(request.id, request.dto);
    }
}