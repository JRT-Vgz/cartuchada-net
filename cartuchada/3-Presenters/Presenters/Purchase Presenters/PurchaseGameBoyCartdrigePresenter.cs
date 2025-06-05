
using _2_Services.Interfaces;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class PurchaseGameBoyCartdrigePresenter : IPresenterWithReference<CartdrigePurchaseDto, CartdrigePurchaseViewModel>
    {
        public CartdrigePurchaseViewModel Present(CartdrigePurchaseDto cartdrigePurchaseDto, string reference)
        {
            var viewModel = new CartdrigePurchaseViewModel
            {
                Reference = $"*** REFERENCIA ASIGNADA: {reference} ***",
                Name = cartdrigePurchaseDto.Name,
                ProductType = $"Producto: {cartdrigePurchaseDto.ProductType}",
                Region = $"Región: {cartdrigePurchaseDto.Region}",
                Condition = $"Condición: {cartdrigePurchaseDto.Condition}",
                PurchasePrice = $"Precio de compra: {cartdrigePurchaseDto.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
