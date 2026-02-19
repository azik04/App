using App.Application.Common.DTO.Job;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Job;
using App.Application.Common.Responses;
using App.Domain.Entities.Main;
using MediatR;

namespace App.Application.Job.Query.GetById;

public class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQuery, GenericResponse<GetByIdJobDto>>
{
    private readonly IGenericRepository<Jobs> _jobRepository;
    public GetByIdJobQueryHandler(IGenericRepository<Jobs> jobRepository) => _jobRepository = jobRepository;


    public async Task<GenericResponse<GetByIdJobDto>> Handle(GetByIdJobQuery request, CancellationToken cancellationToken)
    {
        var item = await _jobRepository.GetByIdAsync(request.id);

        var dto = new GetByIdJobDto
        {
            AddressId = item.AddressId,
            AdressName = item.Address.Name,
            X = item.Address.X,
            Y = item.Address.Y,
            Description = item.Description,
            ClientId = item.ClientId,
            ClientName = item.Client.Name + " " + item.Client.Surname,
            WorkerId = item.WorkerId,
            WorkerName = item.Worker.Name + " " + item.Worker.Surname,
            WorkerRating = item.Worker.Rating,
            ServiceId = item.ServiceId,
            ServiceName = item.Service.Name,
            isActive = item.isActive,
            isHandled = item.isHandled,
            Name = item.Name,
            StatusId = item.StatusId,
            StatusName = item.Statuse.Name,
            AppFile = item.JobFile.Select(ph => ph.FilePath).ToList()
        };

        return GenericResponse<GetByIdJobDto>.Ok(dto);
    }
}
