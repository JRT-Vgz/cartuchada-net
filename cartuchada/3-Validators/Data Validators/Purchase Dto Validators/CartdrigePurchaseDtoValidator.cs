
using _3_Mappers.DTOs.Purchase_Dtos;
using FluentValidation;

namespace _3_Validators.Data_Validators.Purchase_Dto_Validators
{
    public class CartdrigePurchaseDtoValidator : AbstractValidator<CartdrigePurchaseDto>
    {
        public CartdrigePurchaseDtoValidator()
        {
            RuleFor(dto => dto.IdProductType)
                .NotEmpty()
                    .WithMessage("El campo 'IdProductType' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdProductType' debe ser mayor a 0.");

            RuleFor(dto => dto.IdGame)
                .NotEmpty()
                    .WithMessage("El campo 'IdGame' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdGame' debe ser mayor a 0.");

            RuleFor(dto => dto.IdRegion)
                .NotEmpty()
                    .WithMessage("El campo 'IdRegion' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdRegion' debe ser mayor a 0.");

            RuleFor(dto => dto.IdCondition)
                .NotEmpty()
                    .WithMessage("El campo 'IdCondition' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'IdCondition' debe ser mayor a 0.");

            RuleFor(dto => dto.PurchasePrice)
                .NotEmpty()
                    .WithMessage("El campo 'PurchasePrice' es obligatorio.")
                .GreaterThan(0)
                    .WithMessage("El valor del campo 'PurchasePrice' debe ser mayor a 0.")
                .Must(value => decimal.Round(value, 2) == value)
                    .WithMessage("El campo 'PurchasePrice' no puede tener más de dos decimales.");

            RuleFor(dto => dto.Name)
                .NotEmpty()
                    .WithMessage("El campo 'Name' es obligatorio.")
                .MaximumLength(100)
                    .WithMessage("El campo 'Name' no puede superar los 100 caracteres.")
                .Matches("^[a-zA-Z0-9áéíóúÁÉÍÓÚàèìòùÀÈÌÒÙäëïöüÄËÏÖÜÑñçÇ& ]*$")
                    .WithMessage("El campo 'Name' solo puede contener caracteres alfanuméricos y espacios.");
        }
    }
}
