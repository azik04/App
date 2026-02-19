using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Command.Create;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    public CreateAddressCommandHandler(IGenericRepository<Addresses> addressRepository) => _addressRepository = addressRepository;


    public async Task<GenericResponse<bool>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var data = new Addresses()
        {
            Address = request.Address,
            ClientId = request.ClientId,
            Name = request.Name,
            X = request.X,
            Y = request.Y
        };

        await _addressRepository.InsertAsync(data);
        return GenericResponse<bool>.Ok(true);
    }
}
