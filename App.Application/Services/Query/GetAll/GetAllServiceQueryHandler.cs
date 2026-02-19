using App.Application.Common.DTO.Service;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Query.GetAll;

public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, GenericResponse<List<GetAllServiceDto>>>
{
    private readonly IGenericRepository<Domain.Entities.List.Services> _genericRepository;
    public GetAllServiceQueryHandler(IGenericRepository<Domain.Entities.List.Services> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<List<GetAllServiceDto>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
    {
        var data = await _genericRepository.GetAllAsync();

        var dto = data.Select(item => new GetAllServiceDto
        {
            Id = item.Id,
            Name = item.Name,
        }).ToList();

        return GenericResponse<List<GetAllServiceDto>>.Ok(dto);
    }
}
