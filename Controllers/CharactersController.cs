using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Backend_Csharp.Services;
using Proyecto_Backend_Csharp.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController
    (
        ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO> characterService,
        IValidator<CharacterInsertDTO> characterInsertValidator,
        IValidator<CharacterUpdateDTO> characterUpdateValidator
    ) : ControllerBase
    {
        private readonly ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO> _characterService = characterService;
        private readonly IValidator<CharacterInsertDTO> _characterInsertValidator = characterInsertValidator;
        private readonly IValidator<CharacterUpdateDTO> _characterUpdateValidator = characterUpdateValidator;

        [HttpGet]
        public async Task<IEnumerable<CharacterDTO>> Get() => await _characterService.Get();

        [HttpGet("{Id}")]
        public async Task<ActionResult<CharacterDTO>> GetById(int Id)
        {
            var CharacterDTO = await _characterService.GetById(Id);
            return CharacterDTO == null ? NotFound() : Ok(CharacterDTO);
        }
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> Add(CharacterInsertDTO characterInsertDTO)
        {
            var ValidationResult = await _characterInsertValidator.ValidateAsync(characterInsertDTO);

            if (!ValidationResult.IsValid) return BadRequest(ValidationResult.Errors);    
            if (!_characterService.Validate(characterInsertDTO)) return BadRequest(_characterService.Errors);

            var CharacterDTO = await _characterService.Add(characterInsertDTO);

            return CreatedAtAction(nameof(GetById), new {Id = CharacterDTO.CharacterId}, CharacterDTO);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<CharacterDTO>> Update(int Id, CharacterUpdateDTO characterToUpdate)
        {
            var ValidationResult = await _characterUpdateValidator.ValidateAsync(characterToUpdate);

            if (!ValidationResult.IsValid) return BadRequest();
            if (!_characterService.Validate(characterToUpdate)) return BadRequest(_characterService.Errors);

            var CharacterDTO = await _characterService.Update(Id,characterToUpdate);

            return CharacterDTO == null ? BadRequest() : Ok(CharacterDTO);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CharacterDTO>> Delete(int Id)
        {
            var CharacterDeleted = await _characterService.DeleteById(Id);
            return CharacterDeleted == null ? BadRequest() : Ok(CharacterDeleted);
        }
    }
}   
