using DGS.BusinessObjects;
using DGS.BusinessObjects.DTOs.Auth;
using DGS.BusinessObjects.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DGS.API.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public AuthService(UserManager<ApplicationUser> userManager, TokenService tokenService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<IdentityResult> SignUp(RegisterDTO request)
        {
            var NewUser = new ApplicationUser
            {
                DisplayName = request.DisplayName,
                ImageURL = request.ImageURL,
                Gender = request.Gender,
                BirthDay = request.BirthDay,
                Email = request.Email,
                UserName = request.Email
            };
            var result = await _userManager.CreateAsync(NewUser, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
            await _userManager.AddToRoleAsync(NewUser, "Customer");
            return result;
        }

        public async Task<UserClientDTO> SignIn(SignInDTO request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("User name or password wrong !!!");
            }

            string jti = Guid.NewGuid().ToString();

            return new UserClientDTO
            {
                Email = user.Email,
                AccessToken = await _tokenService.GenerateToken(user, jti),
                RefreshToken = await _tokenService.GenerateRefreshToken(jti, user.Id)
            };
        }
       
    }
}
