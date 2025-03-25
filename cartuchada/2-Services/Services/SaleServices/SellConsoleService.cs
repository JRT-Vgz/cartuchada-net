
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class SellConsoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<SoldVideoConsole> _soldConsoleValidator;
        public SellConsoleService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<SoldVideoConsole> soldConsoleValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _soldConsoleValidator = soldConsoleValidator;
        }

        public async Task ExecuteAsync(VideoConsole videoConsole, decimal salePrice)
        {
            try
            {
                if (videoConsole == null) { throw new Exception("Error: El objeto que intenta venderse tiene un valor nulo."); }

                var soldVideoConsole = _mapper.Map<SoldVideoConsole>(videoConsole);
                soldVideoConsole.AssignSalePrice(salePrice);

                bool soldProductIsValid = await _soldConsoleValidator.ValidateProductAsync(soldVideoConsole);
                if (!soldProductIsValid) { throw new ProductValidationException(_soldConsoleValidator.Errors); }

                await _referenceSystem.ReleaseReferenceByIdAsync(videoConsole.IdReference);

                await _unitOfWork.ConsoleRepository.Delete(videoConsole);
                await _unitOfWork.SoldConsoleRepository.AddAsync(soldVideoConsole);

                await _statisticsSystem.SumOneSoldConsoleToStatisticsAsync(soldVideoConsole.IdProductType);
                await _accountingSystem.SumSalePriceToIncomeAsync(soldVideoConsole.SaleDate, salePrice);

                string logEntry = $"VENTA: Consola. Ref: {videoConsole.Reference}, Nombre: {videoConsole.Name}, " +
                    $"Precio de venta: {salePrice}€";
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
