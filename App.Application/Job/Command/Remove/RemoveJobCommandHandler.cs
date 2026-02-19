using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Remove;

public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public RemoveJobCommandHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<bool>> Handle(RemoveJobCommand request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(request.id);
        if (item == null)
            return GenericResponse<bool>.Fail();

        _jobRepository.Delete(item);

        return GenericResponse<bool>.Ok(true);
    }
}
