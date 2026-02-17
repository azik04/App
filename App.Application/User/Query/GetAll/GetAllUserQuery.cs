using App.Application.Common.DTO.User;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.User.Query.GetAll;

public record GetAllUserQuery(string role) : IRequest<GenericResponse<List<GetAllUserDto>>>;
