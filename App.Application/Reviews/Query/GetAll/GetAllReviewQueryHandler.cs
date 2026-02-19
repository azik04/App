using App.Application.Common.DTO.Review;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Reviews;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Reviews.Query.GetAll;

public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GenericResponse<List<GetAllReviewDto>>>
{
    private readonly IGenericRepository<Domain.Entities.Main.Reviews> _genericRepository;
    public GetAllReviewQueryHandler(IGenericRepository<Domain.Entities.Main.Reviews> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<List<GetAllReviewDto>>> Handle(GetAllReviewQuery query, CancellationToken cancellationToken)
    {
        var data = await _genericRepository
            .Where(x => x.WorkerId == query.workerId)
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
