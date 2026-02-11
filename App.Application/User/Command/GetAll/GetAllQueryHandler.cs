using App.Application.Common.DTO.User;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.User.Command.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GenericResponse<List<GetAllUserDto>>>
{
    private readonly IUserService _userService;

    public GetAllQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<GenericResponse<List<GetAllUserDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Role))
            return GenericResponse<List<GetAllUserDto>>.Fail("No role provided");
        
        return await _userService.GetAllUsersAsync(request.Role);
    }
}