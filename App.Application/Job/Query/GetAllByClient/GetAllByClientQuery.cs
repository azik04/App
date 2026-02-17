using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByClient;

public record GetAllByClientQuery(Guid clientId) : IRequest<GenericResponse<List<GetAllJobDto>>>;