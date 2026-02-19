using App.Application.Common.DTO.Review;
using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Reviews.Command.Create;

public sealed record CreateReviewCommand( List<IFormFile> file, string Name, Guid ClientId, Guid WorkerId, int Stars ) 
    : IRequest<GenericResponse<bool>>;
