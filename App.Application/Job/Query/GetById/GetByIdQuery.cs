using App.Application.Common.DTO.Job;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Job.Query.GetById;

public record GetByIdQuery(Guid id) : IRequest<GenericResponse<GetByIdJobDto>>;