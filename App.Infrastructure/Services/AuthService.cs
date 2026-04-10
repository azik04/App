using App.Application.Common.DTO.Auth;
using App.Application.Common.DTO.Jwt;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Auth;
using App.Application.Common.Interfaces.Helpers;
using App.Application.Common.Responses;
using App.Domain.Entities.Acc;
using App.Domain.Enums;
using App.Infrastructure.Identity;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace App.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUsers> _userManager;
    private readonly SignInManager<ApplicationUsers> _signInManager;
    private readonly ITokenHelper _tokenService;
    private readonly IGenericRepository<Refreshes> _refreshesRepository;
    private readonly IGenericRepository<Clients> _clientRepository;
    private readonly IGenericRepository<Workers> _workerRepository;

    public AuthService(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager,
    ITokenHelper tokenService, IGenericRepository<Refreshes> refreshesRepository, IGenericRepository<Clients> clientRepository, IGenericRepository<Workers> workerRepository)
    {
        _userManager = userManager;
        _clientRepository = clientRepository;
        _workerRepository = workerRepository;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _refreshesRepository = refreshesRepository;
    }

    public async Task<TokenResponse> SignInAsync(AuthDto dto)
    {
        ApplicationUsers? entity = null;

        if (dto.AuthType == (int)AuthType.System)
        {
            entity = await _userManager.FindByEmailAsync(dto.Email);
            
            var data = await _signInManager.CheckPasswordSignInAsync(entity, dto.Password, lockoutOnFailure: false);
            if (!data.Succeeded)
                return TokenResponse.Fail("Password or Email is wrong.");
        }
        else if (dto.AuthType == (int)AuthType.Google)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "641553983301-n4knggtg5vua9ivtimgjkbubrcrjo7j3.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(dto.Token, settings);

            entity = await _userManager.FindByEmailAsync(payload.Email);
        }

        if (entity == null)
            return TokenResponse.Fail("User with this Email aint exist.");

        if (!entity.EmailConfirmed)
            return TokenResponse.Fail("Confirm your email.");
        
        var role = await _userManager.GetRolesAsync(entity);

        string? clientName = null;
        string? workerName = null;

        if (role.FirstOrDefault() == "Worker")
        {
            var name = _workerRepository.GetByIdAsync(entity.WorkerId).Result;
            workerName = name.Name + " " + name.Surname;
        }

        if (role.FirstOrDefault() == "Client")
        {
            var name = _clientRepository.GetByIdAsync(entity.ClientId).Result;
            clientName = name.Name + " " + name.Surname;
        }

        var jwt = new GenerateJwtDto
        {
            Email = entity.Email,
            Role = role.FirstOrDefault(),
            ClientId = entity.ClientId,
            WorkerId = entity.WorkerId,
            AppId = entity.Id,
            ClientName = clientName,
            WorkerName = workerName,
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
            ClientId = data.User.ClientId,
            WorkerId = data.User.WorkerId,
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
