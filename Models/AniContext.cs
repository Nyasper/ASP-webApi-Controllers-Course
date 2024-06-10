using Microsoft.EntityFrameworkCore;


namespace Proyecto_Backend_Csharp.Models;

public class AniContext : DbContext
{
  public AniContext(DbContextOptions<AniContext> options) : base(options){}
  public DbSet<Character> Characters { get; set; }
  public DbSet<Anime> Animes { get; set; }
}
