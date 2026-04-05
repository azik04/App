using App.Application.Common.Responses;
using App.Domain.Enums;
using MediatR;

namespace App.Application.Account.Command.SentMail;

public sealed record SentMailCommand(string Email, EmailTypes EmailTypes) : IRequest<GenericResponse<bool>>;
