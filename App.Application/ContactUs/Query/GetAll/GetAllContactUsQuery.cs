using App.Application.Common.DTO.ContactUs;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Query.GetAll;

public record GetAllContactUsQuery : IRequest<GenericResponse<List<GetAllContactUsDto>>>;