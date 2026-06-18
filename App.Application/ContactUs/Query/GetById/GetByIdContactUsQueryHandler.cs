using App.Application.Common.DTO.ContactUs;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.ContactUs.Query.GetById;

public class GetByIdContactUsQueryHandler : IRequestHandler<GetByIdContactUsQuery, GenericResponse<GetByIdContactUsDto>>
{
    private readonly IGenericRepository<Domain.Entities.Main.ContactUs> _contactUsRepository;
    public GetByIdContactUsQueryHandler(IGenericRepository<Domain.Entities.Main.ContactUs> contactUsRepository)
    {
        _contactUsRepository = contactUsRepository;
    }

    public async Task<GenericResponse<GetByIdContactUsDto>> Handle(GetByIdContactUsQuery request, CancellationToken cancellationToken)
    {
        var data = await _contactUsRepository.GetByIdAsync(request.Id);

        var dto = new GetByIdContactUsDto
        {
            Id = data.Id,
            Email = data.Email,
            FullName = data.FullName,
            Title = data.Title
        };

        return GenericResponse<GetByIdContactUsDto>.Ok(dto);
    }
}
