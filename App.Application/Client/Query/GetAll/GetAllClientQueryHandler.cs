using App.Application.Common.DTO.Client;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Client.Query.GetAll;

public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, GenericResponse<List<GetAllClientDto>>>
{
    private readonly IGenericRepository<Clients> _clientService;
    public GetAllClientQueryHandler(IGenericRepository<Clients> clientService) => _clientService = clientService;
    
    
    public async Task<GenericResponse<List<GetAllClientDto>>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        var data = await _clientService.GetAllAsync();
        
        var dtos = new List<GetAllClientDto>();
        foreach (var item in data)
        {
            var dto = new GetAllClientDto();
            
            dto.Id = item.Id;
            dto.Name = item.Name;
            dto.Surname = item.Surname;
            
            dtos.Add(dto);
        }
        
        return GenericResponse<List<GetAllClientDto>>.Ok(dtos);
    }
}