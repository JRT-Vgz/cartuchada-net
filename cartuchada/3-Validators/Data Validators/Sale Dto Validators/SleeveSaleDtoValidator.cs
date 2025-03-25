
using _3_Mappers.DTOs.Sale_Dtos;
using FluentValidation;

namespace _3_Validators.Data_Validators.Sale_Dto_Validators
{
    public class SleeveSaleDtoValidator : AbstractValidator<SleeveSaleDto>
    {
        public SleeveSaleDtoValidator()
        {
            RuleFor(dto => dto.IdSparePartType)
                .NotEmpty()
                    .WithMessage("El campo 'IdSparePartType' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdSparePartType' debe ser mayor a 0.");

            RuleFor(dto => dto.Quantity)
                .NotEmpty()
                    .WithMessage("El campo 'Quantity' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'Quantity' debe ser mayor a 0.");

            RuleFor(dto => dto.SalePrice)
                .NotEmpty()
                    .WithMessage("El campo 'SalePrice' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'SalePrice' debe ser mayor a 0.");

            RuleFor(dto => dto.Name)
                .NotEmpty()
                    .WithMessage("El campo 'Name' es obligatorio.")
                .MaximumLength(50)
                    .WithMessage("El campo 'Name' no puede superar los 50 caracteres.")
                .Matches("^[a-zA-Z0-9áéíóúÁÉÍÓÚàèìòùÀÈÌÒÙäëïöüÄËÏÖÜÑñçÇ ]*$")
                    .WithMessage("El campo 'Name' solo puede contener caracteres alfanuméricos y espacios.");
        }
    }
}
