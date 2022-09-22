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
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };


                var token = GetToken(authClaims);

                return new LoginResponse
                {
                    Status = "Success",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenExpiration = token.ValidTo
                };
            }
            throw new UnauthorizedAccessException("useer is not authorized");
        }

        public async Task<RegisterResponse> Registration(RegisterQuery request)
        {
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser != null)
            {
                throw new ApplicationException("User already Exists");

            }

            ApplicationUserDTO user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position
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


        public GetUserResponse GetUsers()
        {
            var result =  _userManager.Users.ToList();

            return new GetUserResponse { };
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
