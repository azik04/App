using System;
using System.Collections.Generic;
using System.Text;
using App.Application.Common.DTO.Identity;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Account.Command.Confirm;

public sealed record ConfirmCommand(string UserId, string Token) : IRequest<GenericResponse<bool>>;

