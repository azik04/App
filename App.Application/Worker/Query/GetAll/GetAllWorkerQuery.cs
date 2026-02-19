using App.Application.Common.DTO.Worker;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Worker.Query.GetAll;

public record GetAllWorkerQuery : IRequest<GenericResponse<List<GetAllWorkerDto>>>;