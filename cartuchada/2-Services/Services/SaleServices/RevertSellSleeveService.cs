
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class RevertSellSleeveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SoldSleeve> _soldSleeveValidator;

        public RevertSellSleeveService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStatisticsSystem statisticSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<SoldSleeve> soldSleeveValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statisticsSystem = statisticSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _soldSleeveValidator = soldSleeveValidator;
        }

        public async Task ExecuteAsync(SoldSleeve soldSleeve)
        {
            if (soldSleeve == null) { throw new Exception("Error: La venta de fundas que intenta revertirse tiene un valor nulo."); }

            bool productIsValid = await _soldSleeveValidator.ValidateProductAsync(soldSleeve);
            if (!productIsValid) { throw new ProductValidationException(_soldSleeveValidator.Errors); }

            await _unitOfWork.SoldSleeveRepository.Delete(soldSleeve);

            await _statisticsSystem.WithdrawSoldSleevesFromStatisticsAsync(soldSleeve.IdSparePartType, soldSleeve.Quantity);
            await _accountingSystem.WithdrawSalePriceFromIncomeAsync(soldSleeve.SaleDate, soldSleeve.SalePrice);

            string logEntry = $"REVERTIR VENTA: Fundas. Nombre: {soldSleeve.Name}, Cantidad: {soldSleeve.Quantity}, " +
                $"Fecha de venta: {soldSleeve.SaleDate.ToString("yyyy-MM-dd")}, Precio de venta: {soldSleeve.SalePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
