using App.Application.Common.Responses;
using MediatR;

namespace App.Application.Address.Command.Create;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, GenericResponse<bool>>
{
    public Task<GenericResponse<bool>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
