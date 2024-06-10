namespace Proyecto_Backend_Csharp.DTOs;

public record class CharacterUpdateDTO
{
  public required string Name { get; set; }
  public required int AnimeId { get; set; }
  public required int Age { get; set; }
}
