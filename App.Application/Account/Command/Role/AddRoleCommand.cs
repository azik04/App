using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Role;

public class AddRoleCommand : IRequest<GenericResponse<bool>>;