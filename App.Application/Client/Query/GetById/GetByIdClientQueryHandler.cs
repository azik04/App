using App.Application.Common.DTO.Client;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Client.Query.GetById;

public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, GenericResponse<GetByIdClientDto>>
{
    private readonly IGenericRepository<Clients> _clientService;
    public GetByIdClientQueryHandler(IGenericRepository<Clients> clientService) => _clientService = clientService;
    
    
    public async Task<GenericResponse<GetByIdClientDto>> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
    {
        var data = await _clientService.GetByIdAsync(request.id);

        var dto = new GetByIdClientDto()
        {
            Id = data.Id,
            Name = data.Name,
            Surname = data.Surname,
            ActiveAddress = data.Adresses.FirstOrDefault(x => x.isAcrive == true)?.Address
        };

        return GenericResponse<GetByIdClientDto>.Ok(dto);
    }
}