using App.Application.Common.DTO.Worker;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Worker.Query.GetAll;

public class GetAllWorkerQueryHandler : IRequestHandler<GetAllWorkerQuery, GenericResponse<List<GetAllWorkerDto>>>
{
    private readonly IGenericRepository<Workers> _workersRepository;
    public GetAllWorkerQueryHandler(IGenericRepository<Workers> workersRepository) => _workersRepository = workersRepository;
    
    
    public async Task<GenericResponse<List<GetAllWorkerDto>>> Handle(GetAllWorkerQuery request, CancellationToken cancellationToken)
    {
        var data = await _workersRepository.GetAllAsync();
        
        var dtos = new List<GetAllWorkerDto>();
        foreach (var item in data)
        {
            var dto = new GetAllWorkerDto()
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
            };
            dtos.Add(dto);
        }

        return GenericResponse<List<GetAllWorkerDto>>.Ok(dtos);
    }
}