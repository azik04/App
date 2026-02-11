using App.Application.Common.DTO.Account;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.ChangePassword;

public sealed record ChangePasswordCommand(string userId, ChangePasswordDto dto) : IRequest<GenericResponse<bool>>;
