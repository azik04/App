using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllHandled;

public sealed record GetAllHandledJobQuery(string appId, int serviceId) : IRequest<GenericResponse<List<GetAllJobDto>>>;
