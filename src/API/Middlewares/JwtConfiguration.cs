using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoDBZ.src.API.Middlewares
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secretKey = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expireTime = jwtSettings["ExpireTime"];

            // JWT Authentication
            services.AddAuthentication(opt =>{opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;})
            .AddJwtBearer(opt =>{opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                    };
                });

        

            return services;
        }
        
    }
}