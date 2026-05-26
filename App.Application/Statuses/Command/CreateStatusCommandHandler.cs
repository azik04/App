using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.List;
using MediatR;
using System.Threading;

namespace App.Application.Statuses.Command;

public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.List.Statuses> _statusRepository;
    public CreateStatusCommandHandler(IGenericRepository<Domain.Entities.List.Statuses> statusRepository) => _statusRepository = statusRepository;

    public async Task<GenericResponse<bool>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.List.Statuses()
        {
            Name = request.name
        };

        await _statusRepository.InsertAsync(data);

        return GenericResponse<bool>.Ok(true);
    }
}
