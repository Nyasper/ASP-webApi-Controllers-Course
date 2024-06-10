using Microsoft.EntityFrameworkCore;
using Proyecto_Backend_Csharp.Models;

namespace Proyecto_Backend_Csharp.Repository;

public class CharacterRepository(AniContext context) : IRepository<Character>
{
  private readonly AniContext _context = context;
  public async Task<IEnumerable<Character>> Get() => await _context.Characters.ToListAsync();
  public async Task<Character?> GetById(int id) => await _context.Characters.FindAsync(id);
  public async Task Add(Character character) => await _context.Characters.AddAsync(character);
  public async Task SaveChanges() => await _context.SaveChangesAsync();
  public List<Character> Search(Func<Character, bool> filter) => _context.Characters.Where(filter).ToList();
  public void Update(Character character)
  {
    _context.Characters.Attach(character);
    _context.Entry(character).State = EntityState.Modified;
  }
  public void Delete(Character character) =>_context.Characters.Remove(character);
}
