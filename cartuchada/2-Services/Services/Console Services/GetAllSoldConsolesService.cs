
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Console_Services
{
    public class GetAllSoldConsolesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSoldConsolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SoldVideoConsole>> ExecuteAsync()
        {
            return await _unitOfWork.SoldConsoleRepository.GetAllAsync();
        }
    }
}
