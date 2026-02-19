using App.Application.Common.DTO.Service;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Create;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.List.Services> _genericRepository;
    public CreateServiceCommandHandler(IGenericRepository<Domain.Entities.List.Services> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.List.Services
        {
            Name = request.Name,
        };
        await _genericRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }
}
