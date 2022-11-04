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
using Intranet.Application.User;
using Intranet.Application.Common.Image;

namespace Intranet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUserDTO> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<LoginResponse> Login(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.loginData.Email);
            if (user == null)
            {
                throw new AppException("User with this Email doesn't exist");
            }
            if (await _userManager.CheckPasswordAsync(user, request.loginData.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

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

        public async Task<RegisterResponse> Registration(RegisterQuery request, CancellationToken cancellationToken)
        {
            IdentityResult result;
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
                ProfileLinkedin = request.ProfileLinkedin,
                Image = await ImageConvertor.ImageToByteArr(null, cancellationToken)
            };

            try
            {
                result = await _userManager.CreateAsync(user, request.Password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }

            if (!result.Succeeded)
            {
                throw new AppException(result.Errors.First().Description);
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));


            if (await _roleManager.RoleExistsAsync(UserRoles.Admin) && request.UserRole == UserRole.Admin)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User) && request.UserRole == UserRole.User)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
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
