using _1_Domain.Purchase_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Spare_Parts_Services
{
    public class GetAllSparePartsPurchasesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSparePartsPurchasesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SparePartsPurchase>> ExecuteAsync()
            => await _unitOfWork.SparePartsPurchaseRepository.GetAllAsync();
    }
}
