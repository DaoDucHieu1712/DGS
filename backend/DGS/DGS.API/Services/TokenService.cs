using DGS.BusinessObjects;
using DGS.BusinessObjects.DTOs.Auth;
using DGS.BusinessObjects.Entities;
using DGS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DGS.API.Services
{
    public class TokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public TokenService(UserManager<ApplicationUser> userManager, IConfiguration config, ApplicationDbContext context)
        {
            _userManager = userManager;
            _config = config;
            _context = context;
        }

        public async Task<string> GenerateToken(ApplicationUser user, string jti)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenOptions = new JwtSecurityToken
            (
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<string> GenerateRefreshToken(string jti, string UserId)
        {
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            RefreshToken rf = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                Token = refreshToken,
                JwtId= jti,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddMinutes(30),
            };

            await _context.RefreshTokens.AddAsync(rf);
            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<string> ValidReNewToken(Token request)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JWT:Issuer"],
                ValidAudience = _config["JWT:Audience"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"])),
            };

            //Check 1 : check valid format
            var verifyToken =  jwtTokenHandler.ValidateToken(request.AccessToken, tokenValidateParam, out var validatedToken);
            
            //Check 2 : Check alg
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase);
                if (!result)//false
                {
                    return "Token Invalid";
                }
            }
            var utcExpireDate = long.Parse(verifyToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expireDate = ConvertUnixTimeToDateTime(utcExpireDate);

            //Check 3 : Check accessToken expire
            if (expireDate > DateTime.UtcNow)
            {
                return "Access token has not yet expired";
            }

            //Check 4 : Check refreshToken exist in DB
            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == request.RefreshToken);
            if (storedToken == null)
            {
                return "Refresh token does not exist";
            }

            //Check 5 : Check refreshToken is use/revoked ?
            if (storedToken.IsUsed)
            {
                return "Refresh token has been used";
            }
            if (storedToken.IsRevoked)
            {
                return "Refresh token has been revoked";
            }

            //Check 6 : token match
            var jti = verifyToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (storedToken.JwtId != jti)
            {
                return "Token doesn't match";
            }

            await UsedRefreshToken(storedToken);
            return string.Empty;
        }

        public async Task UsedRefreshToken(RefreshToken refreshToken)
        {
            refreshToken.IsUsed = true;
            _context.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}
