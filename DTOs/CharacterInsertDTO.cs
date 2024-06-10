namespace Proyecto_Backend_Csharp.DTOs;

public record class CharacterInsertDTO
{
  public required string Name { get; set; }
  public required int AnimeId { get; set; }
  public required int Age { get; set; }
}
