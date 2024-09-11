namespace Proyecto_Backend_Csharp.DTOs;

public record class AnimeInsertDTO
{
  public required int Id { get; set; }
  public required string Name { get; set; }
  public required int Episodes { get; set; }
  public required bool Airing { get; set; }
}
