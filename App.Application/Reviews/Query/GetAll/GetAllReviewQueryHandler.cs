using App.Application.Common.DTO.Review;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Reviews.Query.GetAll;

public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GenericResponse<List<GetAllReviewDto>>>
{
    private readonly IReviewService _reviewService;
    public GetAllReviewQueryHandler(IReviewService reviewService) => _reviewService = reviewService;


    public async Task<GenericResponse<List<GetAllReviewDto>>> Handle(GetAllReviewQuery query, CancellationToken cancellationToken)
    {
        return await _reviewService.GetAllAsync(query.workerId);
    }
}
