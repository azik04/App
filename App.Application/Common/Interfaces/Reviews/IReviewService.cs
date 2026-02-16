using App.Application.Common.DTO.Review;
using App.Application.Common.Responses;
using Microsoft.AspNetCore.Http;

namespace App.Application.Common.Interfaces.Reviews;

public interface IReviewService
{
    Task<GenericResponse<bool>> CreateAsync(List<IFormFile> file, CreateReviewDto dto);
    Task<GenericResponse<List<GetAllReviewDto>>> GetAllAsync(Guid workerId);
}