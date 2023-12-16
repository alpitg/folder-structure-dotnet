using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Structure.Data.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Structure.Data;

namespace Structure.Infrastructure.Extensions
{
    public static class JwtExt
    {
        public static void AddJwtExt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings settings;
            settings = GetJwtSettings(configuration);
            services.AddSingleton(settings);

            // Register Jwt as the Authentication service
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(settings.MinutesToExpiration)
                };

                jwtBearerOptions.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken is JwtSecurityToken accessToken)
                        {
                            var userName = accessToken.Claims.FirstOrDefault(a => a.Type == Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub)?.Value;
                            var email = accessToken.Claims.FirstOrDefault(a => a.Type == "Email")?.Value;
                            context.HttpContext.Items["Id"] = userName;
                            var userInfoToken = context.HttpContext.RequestServices.GetRequiredService<UserInfoToken>();
                            userInfoToken.Id = userName;
                            userInfoToken.Email = email;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddAuthorization();
        }

        public static JwtSettings GetJwtSettings(IConfiguration configuration)
        {
            JwtSettings settings = new JwtSettings
            {
                Key = configuration["JwtSettings:key"],
                Audience = configuration["JwtSettings:audience"],
                Issuer = configuration["JwtSettings:issuer"],
                MinutesToExpiration = Convert.ToInt32(configuration["JwtSettings:minutesToExpiration"])
            };

            return settings;
        }
    }
}
