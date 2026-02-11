using App.Application.Common.DTO.User;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.User.Command.GetAll;

public record GetAllQuery(string Role) : IRequest<GenericResponse<List<GetAllUserDto>>>;
