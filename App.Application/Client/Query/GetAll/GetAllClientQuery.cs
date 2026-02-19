using App.Application.Common.DTO.Client;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Client.Query.GetAll;

public class GetAllClientQuery : IRequest<GenericResponse<List<GetAllClientDto>>>;