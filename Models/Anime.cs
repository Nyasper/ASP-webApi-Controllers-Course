namespace Proyecto_Backend_Csharp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Anime
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id {get; set;} 
  public required string Name {get; set;}
  public int Episodes {get; set;} = 0;
  public bool Airing {get; set;} = false;

}
