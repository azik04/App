using App.Application.Common.DTO.Refresh;
using App.Application.Common.Interfaces.Refresh;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Refreshes.Query;

public class GetAllRefreshCommandHandler : IRequestHandler<GetAllRefreshCommand, GenericResponse<List<GetAllRefreshDto>>>
{
    private readonly IRefreshService _refreshService;
    public GetAllRefreshCommandHandler(IRefreshService refreshService)
    {
        _refreshService = refreshService;
    }

    public async Task<GenericResponse<List<GetAllRefreshDto>>> Handle(GetAllRefreshCommand request, CancellationToken cancellationToken)
    {
        return await _refreshService.GetAllAsync();
    }
}
