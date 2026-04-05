using App.Application.Common.Interfaces.Account;
using App.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace App.Application.Account.Command.Role;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, GenericResponse<bool>>
{
    private readonly IAccountService  _accountService;

    public AddRoleCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    
    public async Task<GenericResponse<bool>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var data = await _accountService.AddRoleAsync();
        return data;
    }
}