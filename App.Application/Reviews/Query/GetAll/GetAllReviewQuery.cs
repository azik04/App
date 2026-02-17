using App.Application.Common.DTO.Review;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Reviews.Query.GetAll;

public record GetAllReviewQuery(Guid workerId) : IRequest<GenericResponse<List<GetAllReviewDto>>>;
