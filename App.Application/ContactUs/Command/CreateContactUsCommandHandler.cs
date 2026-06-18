using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Integrations;
using App.Application.Common.Responses;
using App.Domain.Enums;
using MediatR;

namespace App.Application.ContactUs.Command;

public class CreateContactUsCommandHandler : IRequestHandler<CreateContactUsCommand, GenericResponse<bool>>
{
    private readonly IGenericRepository<Domain.Entities.Main.ContactUs> _contactUsRepository;
    private readonly IEmailService _emailService;
    public CreateContactUsCommandHandler(IGenericRepository<Domain.Entities.Main.ContactUs> contactUsRepository, IEmailService emailService)
    {
        _contactUsRepository = contactUsRepository;
        _emailService = emailService;
    }

    public async Task<GenericResponse<bool>> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Main.ContactUs
        {
            Email = request.Email,
            FullName = request.FullName,
            Title = request.Title
        };

        await _contactUsRepository.InsertAsync(data, cancellationToken);
        
        await _emailService.SentAsync(request.Email, EmailTypes.CongratulationMail, null, null);

        return GenericResponse<bool>.Ok(true);
    }
}
