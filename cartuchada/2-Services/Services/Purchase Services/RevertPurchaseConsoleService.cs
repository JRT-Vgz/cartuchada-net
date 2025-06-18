
using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;

namespace _2_Services.Services.Purchase_Services
{
    public class RevertPurchaseConsoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        private readonly IProductValidator<VideoConsole> _consoleValidator;
        public RevertPurchaseConsoleService(IUnitOfWork unitOfWork,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger,
            IProductValidator<VideoConsole> consoleValidator)
        {
            _unitOfWork = unitOfWork;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
            _consoleValidator = consoleValidator;
        }

        public async Task ExecuteAsync(VideoConsole console)
        {
            if (console == null) { throw new Exception("Error: La consola cuya compra intenta revertirse tiene un valor nulo."); }

            bool productIsValid = await _consoleValidator.ValidateProductAsync(console);
            if (!productIsValid) { throw new ProductValidationException(_consoleValidator.Errors); }

            await _referenceSystem.ReleaseReferenceByIdAsync(console.IdReference);

            await _unitOfWork.ConsoleRepository.Delete(console);

            await _statisticsSystem.WithdrawOnePurchasedConsoleFromStatisticsAsync(console.IdProductType);
            await _accountingSystem.WithdrawPurchasePriceFromExpensesAsync(console.PurchaseDate, console.PurchasePrice);

            string logEntry = $"REVERTIR COMPRA: Consola. Ref: {console.Reference}, Nombre: {console.Name}, " +
                $"Fecha de compra: {console.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de compra: {console.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
