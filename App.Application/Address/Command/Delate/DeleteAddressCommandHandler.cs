using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Command.Delate;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    public DeleteAddressCommandHandler(IGenericRepository<Addresses> addressRepository) => _addressRepository = addressRepository;


    public async Task<GenericResponse<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var data = await _addressRepository.GetByIdAsync(request.id);
        if (data == null)
            return GenericResponse<bool>.Ok(false);

        _addressRepository.Delete(data);

        return GenericResponse<bool>.Ok(true);
    }
}