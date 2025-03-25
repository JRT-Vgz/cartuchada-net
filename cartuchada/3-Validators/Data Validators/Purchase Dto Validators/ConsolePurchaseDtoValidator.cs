
using _3_Mappers.DTOs.Purchase_Dtos;
using FluentValidation;

namespace _3_Validators.Data_Validators.Purchase_Dto_Validators
{
    public class ConsolePurchaseDtoValidator : AbstractValidator<ConsolePurchaseDto>
    {
        public ConsolePurchaseDtoValidator()
        {
            RuleFor(dto => dto.IdProductType)
                .NotEmpty()
                    .WithMessage("El campo 'IdProductType' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdProductType' debe ser mayor a 0.");

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
                .Matches("^[a-zA-Z0-9áéíóúÁÉÍÓÚàèìòùÀÈÌÒÙäëïöüÄËÏÖÜÑñçÇ ]*$")
                    .WithMessage("El campo 'Name' solo puede contener caracteres alfanuméricos y espacios.");
        }
    }
}
