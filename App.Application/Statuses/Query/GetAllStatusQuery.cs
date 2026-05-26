using App.Application.Common.DTO.Service;
using App.Application.Common.DTO.Statuses;
using App.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Statuses.Query
{
    public record GetAllStatusQuery : IRequest<GenericResponse<List<GetAllStatusDto>>>;
}
