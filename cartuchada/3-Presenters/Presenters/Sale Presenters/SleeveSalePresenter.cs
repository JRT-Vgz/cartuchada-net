
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Sale_Presenters
{
    public class SleeveSalePresenter : IPresenter<SoldSleeve, SleeveSaleViewModel>
    {
        public SleeveSaleViewModel Present(SoldSleeve soldSleeve)
        {
            var viewModel = new SleeveSaleViewModel
            {
                SparePartType = $"*** {soldSleeve.Name.ToUpper()} ***",
                Quantity = $"Cantidad: {soldSleeve.Quantity}",
                SalePrice = $"Precio de venta: {soldSleeve.SalePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
