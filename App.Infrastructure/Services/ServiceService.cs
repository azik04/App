using App.Application.Common.DTO.Service;
using App.Application.Common.DTO.User;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using App.Domain.Entities.List;

namespace App.Infrastructure.Services;

public class ServiceService : IServiceService
{
    private readonly IGenericRepository<Domain.Entities.List.Services> _genericRepository;
    public ServiceService(IGenericRepository<Domain.Entities.List.Services> genericRepository) => _genericRepository = genericRepository;
    

    public async Task<GenericResponse<bool>> CreateAsync(CreateServiceDto dto)
    {
        var data = new Domain.Entities.List.Services
        {
            Name = dto.Name,
        };
        await _genericRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<List<GetAllServiceDto>>> GetAllAsync()
    {
        var data = await _genericRepository.GetAllAsync();
        
        var dto = data.Select(item => new GetAllServiceDto
        {
            Id = item.Id,
            Name = item.Name,
        }).ToList();
        
        return GenericResponse<List<GetAllServiceDto>>.Ok(dto);
    }

    public async Task<GenericResponse<bool>> RemoveAsync(int Id)
    {
        var data = await _genericRepository.GetByIdAsync(Id);
        if (data == null)
            return GenericResponse<bool>.Fail();

        _genericRepository.Delete(data);

        return GenericResponse<bool>.Ok(true);
    }
}
