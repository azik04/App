using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Command.Handle;

public class HandleJobCommandHandler : IRequestHandler<HandleJobCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public HandleJobCommandHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<bool>> Handle(HandleJobCommand request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(request.id);
        if (item == null)
            return GenericResponse<bool>.Fail();

        switch (item.isHandled)
        {
            case false:
                item.StatusId = 2;
                item.WorkerId = request.workerId;
                item.isHandled = true;
                break;

            case true:
                if (item.ClientId != request.clientId)
                    return GenericResponse<bool>.Fail();

                item.StatusId = 1;
                item.WorkerId = null;
                item.isHandled = false;
                break;
        }

        _jobRepository.Update(item);

        return GenericResponse<bool>.Ok(true);
    }
}
