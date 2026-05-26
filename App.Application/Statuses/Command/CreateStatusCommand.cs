using App.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Statuses.Command
{
    public sealed record CreateStatusCommand (string name) : IRequest<GenericResponse<bool>>;
}
