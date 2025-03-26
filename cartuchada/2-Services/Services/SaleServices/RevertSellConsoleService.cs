
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.SaleServices
{
    public class RevertSellConsoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<VideoConsole> _consoleValidator;
        public RevertSellConsoleService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<VideoConsole> consoleValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _consoleValidator = consoleValidator;
        }

        public async Task ExecuteAsync(SoldVideoConsole soldVideoConsole)
        {
            try
            {
                if (soldVideoConsole == null) { throw new Exception("Error: La venta de consola que intenta revertirse tiene un valor nulo."); }

                var console = _mapper.Map<VideoConsole>(soldVideoConsole);
                await _referenceSystem.AssignReferenceToProductAsync(console);

                bool productIsValid = await _consoleValidator.ValidateProductAsync(console);
                if (!productIsValid) { throw new ProductValidationException(_consoleValidator.Errors); }

                await _unitOfWork.SoldConsoleRepository.Delete(soldVideoConsole);
                await _unitOfWork.ConsoleRepository.AddAsync(console);

                await _statisticsSystem.WithdrawOneSoldConsoleFromStatisticsAsync(soldVideoConsole.IdProductType);
                await _accountingSystem.WithdrawSalePriceFromIncomeAsync(soldVideoConsole.SaleDate, soldVideoConsole.SalePrice);

                string logEntry = $"REVERTIR VENTA: Consola. Nueva ref: {console.Reference}, Nombre: {console.Name}, " +
                    $"Fecha de venta: {soldVideoConsole.SaleDate.ToString("yyyy-MM-dd")}, Precio de venta: {soldVideoConsole.SalePrice}€";
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
