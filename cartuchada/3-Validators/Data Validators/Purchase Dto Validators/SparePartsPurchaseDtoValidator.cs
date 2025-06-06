
using _3_Mappers.DTOs.Purchase_Dtos;
using FluentValidation;

namespace _3_Validators.Data_Validators.Purchase_Dto_Validators
{
    public class SparePartsPurchaseDtoValidator : AbstractValidator<SparePartsPurchaseDto>
    {
        public SparePartsPurchaseDtoValidator()
        {
            RuleFor(dto => dto.IdSparePartType)
                .NotEmpty()
                    .WithMessage("El campo 'IdSparePartType' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdSparePartType' debe ser mayor a 0.");

            RuleFor(dto => dto.Concept)
                .NotEmpty()
                    .WithMessage("El campo 'Concept' es obligatorio.")
                .MaximumLength(125)
                    .WithMessage("El campo 'Concept' no puede superar los 125 caracteres.")
                .Matches("^[a-zA-Z0-9���������������������������������� .,:;-_]*$")
                    .WithMessage("El campo 'Concept' solo puede contener caracteres alfanum�ricos, espacios y signos de puntuaci�n.");

            RuleFor(dto => dto.PurchasePrice)
                .NotEmpty()
                    .WithMessage("El campo 'PurchasePrice' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'PurchasePrice' debe ser mayor a 0.");

            RuleFor(dto => dto.Name)
                .NotEmpty()
                    .WithMessage("El campo 'Name' es obligatorio.")
                .MaximumLength(50)
                    .WithMessage("El campo 'Name' no puede superar los 50 caracteres.")
                .Matches("^[a-zA-Z0-9���������������������������������� ]*$")
                    .WithMessage("El campo 'Name' solo puede contener caracteres alfanum�ricos y espacios.");
        }
    }
}
