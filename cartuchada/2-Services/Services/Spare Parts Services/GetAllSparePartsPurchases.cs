using _1_Entities.Purchase_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Spare_Parts_Services
{
    public class GetAllSparePartsPurchases
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSparePartsPurchases(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SparePartsPurchase>> ExecuteAsync()
            => await _unitOfWork.SparePartsPurchaseRepository.GetAllAsync();
    }
}
