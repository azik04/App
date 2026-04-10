using App.Application.Common.DTO.Refresh;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Refreshes.Query;

public sealed record GetAllRefreshCommand : IRequest<GenericResponse<List<GetAllRefreshDto>>> { }
