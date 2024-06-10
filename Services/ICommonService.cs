namespace Proyecto_Backend_Csharp.Services;

public interface ICommonService<T, TI, TU>
{
  public List<string> Errors { get; }
  public Task<IEnumerable<T>> Get();
  public Task<T?> GetById(int Id);
  public Task<T> Add(TI ItemToInsertDTO);
  public Task<T?> Update(int Id, TU ItemToUpdate);
  public Task<T?> DeleteById(int Id);
  public bool Validate(TI InsertDto);
  public bool Validate(TU UpdateDto);
}
