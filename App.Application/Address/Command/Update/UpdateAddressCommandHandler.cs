using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Command.Update;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    public UpdateAddressCommandHandler(IGenericRepository<Addresses> addressRepository) => _addressRepository = addressRepository;


    public async Task<GenericResponse<bool>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var data = await _addressRepository.GetByIdAsync(request.Id);
        if (data == null)
            return GenericResponse<bool>.Ok(false);

        data.Address = request.Address;
        data.X = request.X;
        data.Y = request.Y;
        data.Name = request.Name;

        _addressRepository.Update(data);

        return GenericResponse<bool>.Ok(true);
    }
}