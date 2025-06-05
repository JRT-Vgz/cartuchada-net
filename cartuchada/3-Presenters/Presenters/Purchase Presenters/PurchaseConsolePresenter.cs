
using _2_Services.Interfaces;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class PurchaseConsolePresenter : IPresenterWithReference<ConsolePurchaseDto, ConsolePurchaseViewModel>
    {
        public ConsolePurchaseViewModel Present(ConsolePurchaseDto consolePurchaseDto, string reference)
        {
            var viewModel = new ConsolePurchaseViewModel
            {
                Reference = $"*** REFERENCIA ASIGNADA: {reference} ***",
                Name = $"Producto: {consolePurchaseDto.Name}",
                PurchasePrice = $"Precio de compra: {consolePurchaseDto.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
