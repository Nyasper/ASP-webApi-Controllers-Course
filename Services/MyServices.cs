using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Services;

namespace Proyecto_Backend_Csharp.Services;

public static class ServicesRegister
{
  public static void AddMyServices(this IServiceCollection services)
  {
    services.AddScoped<ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO>, CharacterService>();
  }
}
