using App.Application.Common.DTO.Identity;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public sealed record SignUpCommand(CreateIdentityDto Dto) : IRequest<GenericResponse<bool>>;

