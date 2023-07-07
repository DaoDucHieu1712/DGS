using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, TokenService tokenService, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

        public async Task SignUp(RegisterDTO request)
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
                throw new Exception("Register Failed !!");
            }
            var roleRs =  await _userManager.AddToRoleAsync(NewUser, "Customer");
            if(!roleRs.Succeeded)
            {
                throw new Exception("Not Add To Role");
            }
        }

        public async Task<UserClientDTO> SignIn(SignInDTO request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new UserClientDTO
            {
                Email = user.Email,
                Roles = roles,
                AccessToken = await _tokenService.GenerateToken(user)
            };
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
