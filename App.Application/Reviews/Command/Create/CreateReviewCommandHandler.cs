using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Reviews.Command.Create;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, GenericResponse<bool>>
{
    private readonly IReviewService _reviewService;
    public CreateReviewCommandHandler(IReviewService reviewService) => _reviewService = reviewService;


    public async Task<GenericResponse<bool>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        return await _reviewService.CreateAsync(request.file, request.dto);
    }
}
