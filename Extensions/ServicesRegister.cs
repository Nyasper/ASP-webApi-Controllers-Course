using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Services;

namespace Proyecto_Backend_Csharp.Extensions;

public static class ServicesRegister
{
  public static IServiceCollection AddMyServices(this IServiceCollection services)
  {
    services.AddScoped<ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO>, CharacterService>();
    services.AddScoped<ICommonService<AnimeDTO, AnimeInsertDTO, AnimeUpdateDTO>, AnimeService>();

    return services;
  }

  public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
  {
    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
      };
    });
    return services;
  }
}
