
using _1_Domain.Product_Entities;
using _2_Services.Exceptions;
using _2_Services.Interfaces;

namespace _2_Services.Services.Cartdrige_Services
{
    public class RevertSpotCartdrigePurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly ILogger _logger;
        private readonly INonReferencedProductValidator<Cartdrige> _spotedCartdrigeValidator;

        public RevertSpotCartdrigePurchaseService(IUnitOfWork unitOfWork,
            IStatisticsSystem statisticsSystem,
            ILogger logger,
            INonReferencedProductValidator<Cartdrige> spotedCartdrigeValidator)
        {
            _unitOfWork = unitOfWork;
            _statisticsSystem = statisticsSystem;
            _logger = logger;
            _spotedCartdrigeValidator = spotedCartdrigeValidator;
        }

        public async Task ExecuteAsync(Cartdrige cartdrige)
        {
            if (cartdrige == null) { throw new Exception("Error: El cartucho cuyo spot intenta revertirse tiene un valor nulo."); }

            bool productIsValid = await _spotedCartdrigeValidator.ValidateProductAsync(cartdrige);
            if (!productIsValid) { throw new ProductValidationException(_spotedCartdrigeValidator.Errors); }

            await _unitOfWork.SpotRepository.Delete(cartdrige);

            await _statisticsSystem.WithdrawOneSpotGameBoyCartdrigeFromStatisticsAsync();

            string logEntry = $"REVERTIDO SPOT: Cartucho Game Boy. Id del juego: {cartdrige.IdGame}, Nombre: {cartdrige.Name}, " +
                $"Fecha de spot: {cartdrige.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de spot: {cartdrige.PurchasePrice}€";
            await _logger.WriteLogEntryAsync(logEntry);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
