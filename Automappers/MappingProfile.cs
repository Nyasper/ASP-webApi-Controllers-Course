using AutoMapper;
using Proyecto_Backend_Csharp.Models;
using Proyecto_Backend_Csharp.DTOs;

namespace Proyecto_Backend_Csharp;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CharacterInsertDTO, Character>();
    CreateMap<Character, CharacterDTO>();
    CreateMap<CharacterUpdateDTO, Character>();
  }
}
