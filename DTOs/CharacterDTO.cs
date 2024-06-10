namespace Proyecto_Backend_Csharp.DTOs;

public record class CharacterDTO
{
  public required int CharacterId { get; set; }
  public required string Name { get; set; }
  public required int AnimeId { get; set; }
  public required int Age { get; set; }
}