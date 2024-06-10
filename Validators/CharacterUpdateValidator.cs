using FluentValidation;
using Proyecto_Backend_Csharp.DTOs;
namespace Proyecto_Backend_Csharp;

public class CharacterUpdateValidator : AbstractValidator<CharacterUpdateDTO>
{
  public CharacterUpdateValidator()
  {
    RuleFor(c => c.Name).NotEmpty().WithMessage("required name.");
    RuleFor(c => c.Name).Length(2,50).WithMessage("name must be in range 2-50.");
    RuleFor(c => c.AnimeId).NotNull().WithMessage("AnimeID can't be null.");
    RuleFor(c => c.Age).GreaterThan(0).WithMessage("{PropertyName} Can't be greater than 0.");
  }
}
