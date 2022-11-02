using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Intranet.Application.User.GetUser;
using Intranet.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Intranet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUserDTO> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginQuery request)
        {
            var user = await _userManager.FindByEmailAsync(request.loginData.Email);
            if (user == null)
            {
                throw new AppException("User with this Email doesn't exist");
            }
            if (await _userManager.CheckPasswordAsync(user, request.loginData.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };


                var token = GetToken(authClaims);

                return new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenExpiration = token.ValidTo,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.UserId,
                    ImgUrl = $"{request.HttpContext.Request.Host.Value}/Employee/Image/{user.UserId}"
                };
            }
            throw new AppException("Email or password is incorrect");
        }

        public async Task<RegisterResponse> Registration(RegisterQuery request)
        {
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser != null)
            {
                throw new AppException("User with this Email already Exists");
            }

            ApplicationUserDTO user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
                ProfileFacebook = request.ProfileFacebook,
                ProfileInstagram = request.ProfileInstagram,
                ProfileLinkedin = request.ProfileLinkedin
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Proccess was not copleted");
            }

            return new RegisterResponse
            {
                Message = "Succes"
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
