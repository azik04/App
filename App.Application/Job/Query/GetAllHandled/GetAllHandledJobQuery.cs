using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using App.Domain.Enums;
using MediatR;

namespace App.Application.Job.Query.GetAllHandled;

public sealed record GetAllHandledJobQuery(string appId, int serviceId, Statuses jobStatus) : IRequest<GenericResponse<List<GetAllJobDto>>>;
