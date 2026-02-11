using App.Application.Common.DTO.Auth;
using App.Application.Common.DTO.Jwt;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUsers> _userManager;
    private readonly SignInManager<ApplicationUsers> _signInManager;
    private readonly ITokenHelper _tokenService;
    private readonly IGenericRepository<Refreshes> _refreshesRepository;

    public AuthService(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager,
    ITokenHelper tokenService, IGenericRepository<Refreshes> refreshesRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _refreshesRepository = refreshesRepository;
    }

    public async Task<TokenResponse> AuthAsync(AuthDto dto)
     {
        var entity = await _userManager.FindByEmailAsync(dto.Email);
        if (entity == null)
            return TokenResponse.Fail("User with this Email aint exist.");

        var data = await _signInManager.CheckPasswordSignInAsync(entity, dto.Password, lockoutOnFailure: false);
        if (!data.Succeeded)
            return TokenResponse.Fail("Something went wrong.");

        var jwt = new GenerateJwtDto
        {
            Email = entity.Email,
            Id = entity.Id,
        };

        var accessToken = _tokenService.GenerateAccessToken(jwt);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var refresh = new Refreshes()
        {
            Id = Guid.NewGuid(),
            IsRevoked = false,
            Token = refreshToken,
            UserId = entity.Id,
            ExpiryDate = DateTime.Now.AddDays(1),
        };

        await _refreshesRepository.InsertAsync(refresh);

        return TokenResponse.Ok(accessToken, refreshToken);
     }

     public Task<GenericResponse<string>> GenerateRefrashToken(string refrashToken)
     {
         throw new NotImplementedException();
     }
}
