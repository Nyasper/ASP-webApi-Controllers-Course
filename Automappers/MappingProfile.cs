using AutoMapper;
using Proyecto_Backend_Csharp.Models;
using Proyecto_Backend_Csharp.DTOs;

namespace Proyecto_Backend_Csharp;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    // Character
    CreateMap<Character, CharacterDTO>();
    CreateMap<CharacterInsertDTO, Character>();
    CreateMap<CharacterUpdateDTO, Character>();

    // Anime
    CreateMap<Anime, AnimeDTO>();
    CreateMap<AnimeInsertDTO, Anime>();
    CreateMap<AnimeUpdateDTO, Anime>();
  }
}
