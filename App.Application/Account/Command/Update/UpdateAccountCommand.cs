using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace App.Application.Account.Command.Update;

public sealed record UpdateAccountCommand(
    string id,
    string name,
    string surname,
    string phoneNumber,
    IFormFile file
): IRequest<GenericResponse<bool>>;
