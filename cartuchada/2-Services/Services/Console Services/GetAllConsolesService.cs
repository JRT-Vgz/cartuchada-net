using _1_Domain.Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Console_Services
{
    public class GetAllConsolesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllConsolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VideoConsole>> ExecuteAsync()
        {
            return await _unitOfWork.ConsoleRepository.GetAllAsync();
        }
    }
}
