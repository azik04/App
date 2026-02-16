using App.Application.Common.DTO.Review;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IGenericRepository<Reviews> _genericRepository;
    public ReviewService(IGenericRepository<Reviews> genericRepository) => _genericRepository = genericRepository;
    
    public async Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, CreateReviewDto dto)
    {
        var data = new Reviews()
        {
            ClientId = dto.ClientId,
            WorkerId = dto.WorkerId,
            Name = dto.Name,
            Stars = dto.Stars
        };
        
        await _genericRepository.InsertAsync(data);
        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<List<GetAllReviewDto>>> GetAllAsync(Guid workerId)
    {
        var data = await _genericRepository
            .Where(x => x.WorkerId == workerId)
            .Include(x => x.Client)
            .Include(x => x.Worker)
            .Select(item => new GetAllReviewDto()
            {
                ClientId = item.ClientId,
                ClientName = item.Client.Name,
                Id = item.Id,
                Name = item.Name,
                Stars = item.Stars
            }).ToListAsync();
        
        return GenericResponse<List<GetAllReviewDto>>.Ok(data);
    }
}