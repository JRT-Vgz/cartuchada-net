using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using AutoMapper;

namespace _2_Services.Services.Purchase_Services
{
    public class PurchaseConsoleService<TDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<VideoConsole> _consoleValidator;
        public PurchaseConsoleService(IUnitOfWork unitOfWork,
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

        public async Task ExecuteAsync(TDto consoleDto)
        {
            try
            {
                var console = _mapper.Map<VideoConsole>(consoleDto);

                await _referenceSystem.AssignReferenceToProductAsync(console);

                bool productIsValid = await _consoleValidator.ValidateProductAsync(console);
                if (!productIsValid) { throw new ProductValidationException(_consoleValidator.Errors); }

                await _unitOfWork.ConsoleRepository.AddAsync(console);

                await _statisticsSystem.SumOnePurchasedConsoleToStatisticsAsync(console.IdProductType);
                await _accountingSystem.SumPurchasePriceToExpensesAsync(console.PurchaseDate, console.PurchasePrice);

                string logEntry = $"COMPRA: Consola. Ref: {console.Reference}, Nombre: {console.Name}, " +
                    $"Precio de compra: {console.PurchasePrice}€";
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
