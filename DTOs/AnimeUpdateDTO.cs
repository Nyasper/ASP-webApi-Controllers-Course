namespace Proyecto_Backend_Csharp.DTOs;

public record class AnimeUpdateDTO
{
  public required string Name { get; set; }
  public required int Episodes { get; set; }
  public required bool Airing { get; set; }
}
