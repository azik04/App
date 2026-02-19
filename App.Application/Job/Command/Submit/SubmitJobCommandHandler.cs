using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Submit;

public class SubmitJobCommandHandler : IRequestHandler<SubmitJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public SubmitJobCommandHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<bool>> Handle(SubmitJobCommand request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(request.id);
        if (item == null)
            return GenericResponse<bool>.Fail();

        item.isActive = true;
        item.StatusId = 3;

        _jobRepository.Update(item);

        return GenericResponse<bool>.Ok(true);
    }
}
