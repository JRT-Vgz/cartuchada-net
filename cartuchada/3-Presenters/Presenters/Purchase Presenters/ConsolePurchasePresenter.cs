
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class ConsolePurchasePresenter : IPresenter<VideoConsole, ConsolePurchaseViewModel>
    {
        public ConsolePurchaseViewModel Present(VideoConsole videoConsole)
        {
            var viewModel = new ConsolePurchaseViewModel
            {
                Reference = $"*** REFERENCIA ASIGNADA: {videoConsole.Reference} ***",
                Name = $"Producto: {videoConsole.Name}",
                PurchasePrice = $"Precio de compra: {videoConsole.PurchasePrice}€",
                SparePartsPrice = $"Precio de piezas: {videoConsole.SparePartsPrice}€",
                TotalPrice = $"Precio total: {videoConsole.TotalPrice}€"
            };

            return viewModel;
        }
    }
}
