using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.SignUp;

public sealed record SignUpCommand(CreateIdentityDto Dto) : IRequest<GenericResponse<bool>>;

