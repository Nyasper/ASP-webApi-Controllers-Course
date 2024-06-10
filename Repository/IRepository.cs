namespace Proyecto_Backend_Csharp.Repository;

public interface IRepository<TEntity>
{
  public Task<IEnumerable<TEntity>> Get();
  public Task<TEntity?> GetById(int id);
  public Task Add(TEntity entity);
  public void Update(TEntity entity);
  public void Delete(TEntity entity);
  public Task SaveChanges();
  public List<TEntity> Search(Func<TEntity, bool> filter);
}
