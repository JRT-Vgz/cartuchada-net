
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Cartdrige_Services
{
    public class GetAllSpotCartdrigesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSpotCartdrigesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cartdrige>> ExecuteAsync()
        {
            return await _unitOfWork.SpotRepository.GetAllAsync();
        }
    }
}
