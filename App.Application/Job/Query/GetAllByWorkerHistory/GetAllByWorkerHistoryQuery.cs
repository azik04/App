using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByWorkerHistory;

public record GetAllByWorkerHistoryQuery(Guid workerId) : IRequest<GenericResponse<List<GetAllJobDto>>>;
