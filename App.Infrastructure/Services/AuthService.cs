using App.Application.Common.DTO.Auth;
using App.Application.Common.DTO.Jwt;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TokenResponse> SignInAsync(AuthDto dto)
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

     public async Task<GenericResponse<string>> GenerateAccessTokenAsync(string refrashToken)
     {
         var data = await _refreshesRepository.Where(x => x.Token == refrashToken).SingleOrDefaultAsync();
         if (data == null)
            return GenericResponse<string>.Fail("Refresh token not found.");
             
         if (data.IsRevoked || data.ExpiryDate < DateTime.Now)
             return GenericResponse<string>.Fail("Refresh token is revoke or expired.");
         
         var jwt = new GenerateJwtDto
         {
             Email = data.User.Email,
             Id = data.User.Id,
         };
         
         var accessToken = _tokenService.GenerateAccessToken(jwt);
         return GenericResponse<string>.Ok(accessToken);
     }

     public async Task<GenericResponse<bool>> SignOutAsync(string refreshToken)
     {
         var data = await _refreshesRepository.Where(x => x.Token == refreshToken).SingleOrDefaultAsync();
         if (data == null)
             return GenericResponse<bool>.Fail("Refresh token not found.");
         
         data.IsRevoked = true;
         
         _refreshesRepository.Update(data);
         return GenericResponse<bool>.Ok(true);
     }
}
