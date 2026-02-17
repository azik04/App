using App.Application.Common.DTO.User;
using App.Application.Common.Interfaces.User;
using App.Application.Common.Responses;
using MediatR;

namespace App.Application.User.Query.GetAll;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GenericResponse<List<GetAllUserDto>>>
{
    private readonly IUserService _userService;
    public GetAllUserQueryHandler(IUserService userService) => _userService = userService;
    
    
    public async Task<GenericResponse<List<GetAllUserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Role))
            return GenericResponse<List<GetAllUserDto>>.Fail("No role provided");
        
        return await _userService.GetAllUsersAsync(request.Role);
    }
}