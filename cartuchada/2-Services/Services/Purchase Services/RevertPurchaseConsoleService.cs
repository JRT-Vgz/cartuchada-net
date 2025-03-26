
using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using FluentValidation;

namespace _2_Services.Services.Purchase_Services
{
    public class RevertPurchaseConsoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        public RevertPurchaseConsoleService(IUnitOfWork unitOfWork,
            IReferenceSystem referenceSystem,
            IStatisticsSystem statisticsSystem,
            IAccountingSystem accountingSystem,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _referenceSystem = referenceSystem;
            _statisticsSystem = statisticsSystem;
            _accountingSystem = accountingSystem;
            _logger = logger;
        }

        public async Task ExecuteAsync(VideoConsole console)
        {
            try
            {
                if (console == null) { throw new Exception("Error: La consola cuya compra intenta revertirse tiene un valor nulo."); }

                await _referenceSystem.ReleaseReferenceByIdAsync(console.IdReference);

                await _unitOfWork.ConsoleRepository.Delete(console);

                await _statisticsSystem.WithdrawOnePurchasedConsoleFromStatisticsAsync(console.IdProductType);
                await _accountingSystem.WithdrawPurchasePriceFromExpensesAsync(console.PurchaseDate, console.PurchasePrice);

                string logEntry = $"REVERTIDA COMPRA: Consola. Ref: {console.Reference}, Nombre: {console.Name}, " +
                    $"Fecha de compra: {console.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de compra: {console.PurchasePrice}€";
                await _logger.WriteLogEntryAsync(logEntry);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
