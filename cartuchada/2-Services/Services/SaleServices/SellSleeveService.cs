
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class SellSleeveService<TDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SoldSleeve> _soldSleeveValidator;

        public SellSleeveService(IUnitOfWork unitOfWork,
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

        public async Task ExecuteAsync(TDto sleeveSaleDto)
        {
            try
            {
                var soldSleeve = _mapper.Map<SoldSleeve>(sleeveSaleDto);

                bool productIsValid = await _soldSleeveValidator.ValidateProductAsync(soldSleeve);
                if (!productIsValid) { throw new ProductValidationException(_soldSleeveValidator.Errors); }

                await _unitOfWork.SoldSleeveRepository.AddAsync(soldSleeve);

                await _statisticsSystem.SumSleevesToStatisticsAsync(soldSleeve.IdSparePartType, soldSleeve.Quantity);
                await _accountingSystem.SumSalePriceToIncomeAsync(soldSleeve.SaleDate, soldSleeve.SalePrice);

                string logEntry = $"VENTA: Fundas. Nombre: {soldSleeve.Name}, Cantidad: {soldSleeve.Quantity}, " +
                    $"Precio de venta: {soldSleeve.SalePrice}€";
                await _logger.WriteLogEntryAsync(logEntry);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (ProductValidationException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var error in ex.Errors) { Console.WriteLine(error); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
