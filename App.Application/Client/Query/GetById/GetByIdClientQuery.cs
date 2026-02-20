using System;
using System.Collections.Generic;
using System.Text;
using App.Application.Common.DTO.Client;
using App.Application.Common.DTO.Worker;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Client.Query.GetById
{
    public record GetByIdClientQuery(Guid id) : IRequest<GenericResponse<GetByIdClientDto>>;
}
