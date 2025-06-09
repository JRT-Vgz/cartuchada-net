
using _1_Domain.Purchase_Entities;
using _2_Services.Interfaces;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class SparePartsPurchasePresenter : IPresenter<SparePartsPurchase, SparePartsPurchaseViewModel>
    {
        public SparePartsPurchaseViewModel Present(SparePartsPurchase sparePartsPurchase)
        {
            var viewModel = new SparePartsPurchaseViewModel
            {
                SparePartType = $"*** {sparePartsPurchase.Name.ToUpper()} ***",
                Concept = $"Concepto: {sparePartsPurchase.Concept}",
                PurchasePrice = $"Precio de compra: {sparePartsPurchase.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
