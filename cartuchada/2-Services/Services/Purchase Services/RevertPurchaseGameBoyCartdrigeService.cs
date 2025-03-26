
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Purchase_Services
{
    public class RevertPurchaseGameBoyCartdrigeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferenceSystem _referenceSystem;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly IAccountingSystem _accountingSystem;
        private readonly ILogger _logger;
        public RevertPurchaseGameBoyCartdrigeService(IUnitOfWork unitOfWork,
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

        public async Task ExecuteAsync(Cartdrige cartdrige)
        {
            try
            {
                if (cartdrige == null) { throw new Exception("Error: El cartucho cuya compra intenta revertirse tiene un valor nulo."); }

                await _referenceSystem.ReleaseReferenceByIdAsync(cartdrige.IdReference);

                await _unitOfWork.CartdrigeRepository.Delete(cartdrige);

                await _statisticsSystem.WithdrawOnePurchasedGameBoyCartdrigeFromStatisticsAsync();
                await _accountingSystem.WithdrawPurchasePriceFromExpensesAsync(cartdrige.PurchaseDate, cartdrige.PurchasePrice);

                string logEntry = $"REVERTIDA COMPRA: Cartucho Game Boy. Ref: {cartdrige.Reference}, Nombre: {cartdrige.Name}, " +
                    $"Fecha de compra: {cartdrige.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de compra: {cartdrige.PurchasePrice}€";
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
