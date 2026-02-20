using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using MediatR;

namespace App.Application.Address.Query.GetAll;

public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, GenericResponse<List<GetAllAddressDto>>>
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    public GetAllAddressQueryHandler(IGenericRepository<Addresses> addressRepository) => _addressRepository = addressRepository;


    public async Task<GenericResponse<List<GetAllAddressDto>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        var data = _addressRepository.Where(x => x.ClientId == request.clientId).Select(item => new GetAllAddressDto
        {
            Id = item.Id,
            Name = item.Name,
            Address = item.Address
        }).ToList();

        return GenericResponse<List<GetAllAddressDto>>.Ok(data);
    }
}