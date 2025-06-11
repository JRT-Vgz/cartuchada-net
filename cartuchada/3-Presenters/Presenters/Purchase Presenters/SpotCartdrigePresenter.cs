
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class SpotCartdrigePresenter : IPresenter<Cartdrige, SpotCartdrigeViewModel>
    {
        public SpotCartdrigeViewModel Present(Cartdrige cartdrige)
        {
            var viewModel = new SpotCartdrigeViewModel
            {
                SpotAction = $"*** CARTUCHO SPOTEADO ***",
                Name = cartdrige.Name,
                ProductType = $"Producto: {cartdrige.ProductType}",
                Region = $"Región: {cartdrige.Region}",
                Condition = $"Condición: {cartdrige.Condition}",
                SpotPrice = $"Precio de spot: {cartdrige.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
