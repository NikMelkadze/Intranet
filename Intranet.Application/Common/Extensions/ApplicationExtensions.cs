using FluentValidation;
using Intranet.Application.Catalogs.Interests;
using Intranet.Application.Catalogs.Interests.DeleteInterest;
using Intranet.Application.Catalogs.Interests.GetInterests;
using Intranet.Application.Services;
using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Intranet.Application.Common.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection InstallApplicationExtensions(this IServiceCollection services, ConfigurationManager configuration)
        {

            // Authorization
            _ = services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             })// Adding Jwt Bearer
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = configuration["JWT:ValidAudience"],
                     ValidIssuer = configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                 };
             });

            //Swagger 
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                },
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new string[] { }
        }
    });
            });

            //MediatR
            _ = services.AddMediatR(typeof(LoginQueryHandler).Assembly, typeof(RegisterQueryHandler).Assembly, typeof(CreateInterestCommandHandler).Assembly,
                typeof(GetInterestsQueryHandler).Assembly, typeof(DeleteInterestCommandHandler).Assembly);

            //FluentVladiation
            _ = services.AddValidatorsFromAssembly(typeof(LoginQuery).Assembly);

            //Services
            _ = services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
