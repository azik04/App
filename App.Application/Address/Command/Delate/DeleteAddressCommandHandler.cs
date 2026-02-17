using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Delate;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, GenericResponse<bool>>
{
    private readonly IAddressService _addressService;
    public DeleteAddressCommandHandler(IAddressService addressService) => _addressService = addressService;


    public async Task<GenericResponse<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        return await _addressService.RemoveAsync(request.id);
    }
}