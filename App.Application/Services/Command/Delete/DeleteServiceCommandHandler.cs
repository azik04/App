using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Services.Command.Delete;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.List.Services> _genericRepository;
    public DeleteServiceCommandHandler(IGenericRepository<Domain.Entities.List.Services> genericRepository) => _genericRepository = genericRepository;


    public async Task<GenericResponse<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var data = await _genericRepository.GetByIdAsync(request.id);
        if (data == null)
            return GenericResponse<bool>.Fail();

        _genericRepository.Delete(data);
        

        return GenericResponse<bool>.Ok(true);
    }
}
