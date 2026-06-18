using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Command;

public sealed record CreateContactUsCommand(
    string Email,
    string FullName,
    string Title
) : IRequest<GenericResponse<bool>>;

