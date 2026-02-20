using App.Application.Common.DTO.Client;
using App.Application.Common.DTO.Worker;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Client.Query.GetById;

public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, GenericResponse<GetByIdClientDto>>
{
    private readonly IGenericRepository<Clients> _clientRepository;
    public GetByIdClientQueryHandler(IGenericRepository<Clients> clientRepository) => _clientRepository = clientRepository;


    public async Task<GenericResponse<GetByIdClientDto>> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
    {
        var data = await _clientRepository.Where(x => x.Id == request.id)
            .Include(x => x.Review)
            .Include(x => x.Adresses)
            .Include(x => x.Job)
            .SingleOrDefaultAsync();

        var dto = new GetByIdClientDto()
        {
            Name = data.Name,
            Id = data.Id,
            Surname = data.Surname,
            ActiveAddress = data.Adresses.Where(x => x.isAcrive == true).SingleOrDefault().Address
        };

        return GenericResponse<GetByIdClientDto>.Ok(dto);
    }
}
