
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Sleeve_Services
{
    public class GetAllSoldSleevesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSoldSleevesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SoldSleeve>> ExecuteAsync()
        {
            return await _unitOfWork.SoldSleeveRepository.GetAllAsync();
        }
    }
}
