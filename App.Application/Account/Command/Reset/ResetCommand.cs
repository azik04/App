using App.Application.Common.DTO.Identity;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Reset;

public sealed record ResetCommand(string Email, string Token, ResetPasswordDto Dto) : IRequest<GenericResponse<bool>>;

