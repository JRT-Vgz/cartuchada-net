using _1_Entities.Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Cartdrige_Services
{
    public class GetAllCartdrigesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCartdrigesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cartdrige>> ExecuteAsync()
        {
            return await _unitOfWork.CartdrigeRepository.GetAllAsync();
        }
    }
}
