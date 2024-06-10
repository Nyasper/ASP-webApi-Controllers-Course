using Microsoft.EntityFrameworkCore;
using Proyecto_Backend_Csharp.Models;
using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Repository;
using AutoMapper;

namespace Proyecto_Backend_Csharp.Services;

public class CharacterService(IRepository<Character> repository, IMapper mapper) : ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO>
{
  public List<string> Errors { get; } = [];
  private readonly IRepository<Character> _characterRepository = repository;
  private readonly IMapper _mapper = mapper;

  public async Task<IEnumerable<CharacterDTO>> Get()
  {
    var Characters = await _characterRepository.Get();
    return Characters.Select(c=> mapper.Map<CharacterDTO>(c));
    }
  public async Task<CharacterDTO?> GetById(int Id)
  {
    var character = await _characterRepository.GetById(Id);
    if (character == null) return null;

    return _mapper.Map<CharacterDTO>(character);
  }
  public async Task<CharacterDTO> Add(CharacterInsertDTO CharacterToInsertDTO)
  {
    var character = _mapper.Map<Character>(CharacterToInsertDTO);
    await _characterRepository.Add(character);
    await _characterRepository.SaveChanges();

    return _mapper.Map<CharacterDTO>(character);
  }
  public async Task<CharacterDTO?> Update(int Id, CharacterUpdateDTO characterToUpdate)
  {
    var character = await _characterRepository.GetById(Id);
    if (character is null) return null;

    _characterRepository.Update(character);
    character = _mapper.Map(characterToUpdate, character);
    await _characterRepository.SaveChanges();

    return _mapper.Map<CharacterDTO>(character);
  }
  public async Task<CharacterDTO?> DeleteById(int Id)
  {
    var character = await _characterRepository.GetById(Id);
    if (character == null) return null;

    _characterRepository.Delete(character);
    await _characterRepository.SaveChanges();
    return _mapper.Map<CharacterDTO>(character);
  }
  public bool Validate(CharacterInsertDTO characterInsertDTO)
  {
    if (_characterRepository.Search(c=>c.Name == characterInsertDTO.Name).Count() > 0)
    {
      Errors.Add("Nombre del personaje ya existe");
      return false;
    }
    return true;
  }
  public bool Validate(CharacterUpdateDTO characterUpdateDTO)
  {
    if (_characterRepository.Search(c=>c.Name == characterUpdateDTO.Name &&
    characterUpdateDTO.AnimeId != c.AnimeId).Count() > 0)
    {
      Errors.Add("Nombre del personaje ya existe");
      return false;
    }
    return true;
  }
}
