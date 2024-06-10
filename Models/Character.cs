namespace Proyecto_Backend_Csharp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Character
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
  public int CharacterId { get; set; }
  public required string Name { get; set; }
  [ForeignKey("anime")]
  public int AnimeId { get; set; }
  public int Age { get; set; }
  public required virtual Anime Anime { get; set; }
}
