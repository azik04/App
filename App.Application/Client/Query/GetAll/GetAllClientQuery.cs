using System;
using System.Collections.Generic;
using System.Text;
using App.Application.Common.DTO.Client;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Client.Query.GetAll;

public record GetAllClientQuery : IRequest<GenericResponse<List<GetAllClientDto>>>;
