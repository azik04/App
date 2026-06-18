using App.Application.Common.DTO.ContactUs;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Query.GetById;

public record GetByIdContactUsQuery(long Id) : IRequest<GenericResponse<GetByIdContactUsDto>>;

