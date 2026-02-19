using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Reviews.Command.Create;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.Main.Reviews> _genericRepository;
    public CreateReviewCommandHandler(IGenericRepository<Domain.Entities.Main.Reviews> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Main.Reviews()
        {
            ClientId = request.ClientId,
            WorkerId = request.WorkerId,
            Name = request.Name,
            Stars = request.Stars
        };

        await _genericRepository.InsertAsync(data);
        return GenericResponse<bool>.Ok(true);
    }
}
