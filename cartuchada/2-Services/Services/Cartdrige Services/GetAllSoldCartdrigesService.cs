using _1_Entities.Sold_Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Cartdrige_Services
{
    public class GetAllSoldCartdrigesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSoldCartdrigesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SoldCartdrige>> ExecuteAsync()
        {
            return await _unitOfWork.SoldCartdrigeRepository.GetAllAsync();
        }
    }
}
