
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class CartdrigePurchasePresenter : IPresenter<Cartdrige, CartdrigePurchaseViewModel>
    {
        public CartdrigePurchaseViewModel Present(Cartdrige cartdrige)
        {
            var viewModel = new CartdrigePurchaseViewModel
            {
                Reference = $"*** REFERENCIA ASIGNADA: {cartdrige.Reference} ***",
                Name = cartdrige.Name,
                ProductType = $"Producto: {cartdrige.ProductType}",
                Region = $"Región: {cartdrige.Region}",
                Condition = $"Condición: {cartdrige.Condition}",
                PurchasePrice = $"Precio de compra: {cartdrige.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
