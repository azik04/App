using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetAllByWorker;

public record GetAllByWorkerQuery(int serviceId) : IRequest<GenericResponse<List<GetAllJobDto>>>;
