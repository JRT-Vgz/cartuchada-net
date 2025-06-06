
using _2_Services.Interfaces;
using _3_Mappers.DTOs.Sale_Dtos;
using _3_Presenters.View_Models;

namespace _3_Presenters.Presenters.Sale_Presenters
{
    public class SleeveSalePresenter : IPresenter<SleeveSaleDto, SleeveSaleViewModel>
    {
        public SleeveSaleViewModel Present(SleeveSaleDto sleeveSaleDto)
        {
            var viewModel = new SleeveSaleViewModel
            {
                SparePartType = $"*** {sleeveSaleDto.Name.ToUpper()} ***",
                Quantity = $"Cantidad: {sleeveSaleDto.Quantity}",
                SalePrice = $"Precio de venta: {sleeveSaleDto.SalePrice.ToString()}€"
            };

            return viewModel;
        }
    }
}
