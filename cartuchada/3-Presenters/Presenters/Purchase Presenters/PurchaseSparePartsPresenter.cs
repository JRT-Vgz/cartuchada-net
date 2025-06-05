
using _2_Services.Interfaces;
using _3_Mappers.DTOs.Purchase_Dtos;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Purchase_Presenters
{
    public class PurchaseSparePartsPresenter : IPresenter<SparePartsPurchaseDto, SparePartsPurchaseViewModel>
    {
        public SparePartsPurchaseViewModel Present(SparePartsPurchaseDto sparePartsPurchaseDto)
        {
            var viewModel = new SparePartsPurchaseViewModel
            {
                SparePartType = $"*** {sparePartsPurchaseDto.Name.ToUpper()} ***",
                Concept = $"Concepto: {sparePartsPurchaseDto.Concept}",
                PurchasePrice = $"Precio de compra: {sparePartsPurchaseDto.PurchasePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
