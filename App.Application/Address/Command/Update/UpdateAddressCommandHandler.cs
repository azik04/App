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
        var data = await _addressRepository.GetByIdAsync(request.id);
        if (data == null)
            return GenericResponse<bool>.Ok(false);

        data.Address = request.Address;
        data.Lat = request.Lat;
        data.Lng = request.Lng;
        data.Name = request.Name;

        await _addressRepository.Update(data);

        return GenericResponse<bool>.Ok(true);
    }
}