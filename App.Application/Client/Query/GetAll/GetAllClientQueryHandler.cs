using System;
using System.Collections.Generic;
using System.Text;
using App.Application.Common.DTO.Client;
using App.Application.Common.DTO.Worker;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;

namespace App.Application.Client.Query.GetAll;

public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, GenericResponse<List<GetAllClientDto>>>
{
    private readonly IGenericRepository<Clients> _clientRepository;
    public GetAllClientQueryHandler(IGenericRepository<Clients> clientRepository) => _clientRepository = clientRepository;


    public async Task<GenericResponse<List<GetAllClientDto>>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        var data = await _clientRepository.GetAllAsync();

        var dtos = new List<GetAllClientDto>();
        foreach (var item in data)
        {
            var dto = new GetAllClientDto()
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
            };
            dtos.Add(dto);
        }

        return GenericResponse<List<GetAllClientDto>>.Ok(dtos);
    }
}
