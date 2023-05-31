using FluentValidation;
using HeraclesDAO.Models;

namespace Heracles.Utilities
{
    internal class CoachValidation : AbstractValidator<Coach>
    {
        public CoachValidation()
        {
            RuleFor(coach => coach.Name).NotEmpty().WithMessage("El campo nombre no puede estar vacío");
            RuleFor(c => c.Name).Length(3, 60).WithMessage("Nombre debe tener 3 a 60 caracteres");

            RuleFor(coach => coach.LastName).NotEmpty().WithMessage("El campo apellido no puedo estar vacío");
            RuleFor(c => c.LastName).Length(3, 60).WithMessage("Apellido debe tener 3 a 60 caracteres");

            RuleFor(coach => coach.CI).NotEmpty().WithMessage("El CI no puede estar vacío");
            RuleFor(coach => coach.CI).Length(7, 15).WithMessage("El número de CI no es correcto");

            RuleFor(coach => coach.Phone).NotEmpty().WithMessage("El campo teléfono no puede estar vacío");
            RuleFor(coach => coach.Phone).Length(8).WithMessage("El número de teléfono tiene 8 dígitos");
        }
    }
}
