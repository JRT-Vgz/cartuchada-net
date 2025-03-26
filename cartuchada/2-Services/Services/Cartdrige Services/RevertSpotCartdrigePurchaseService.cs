
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;

namespace _2_Services.Services.Cartdrige_Services
{
    public class RevertSpotCartdrigePurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsSystem _statisticsSystem;
        private readonly ILogger _logger;
        public RevertSpotCartdrigePurchaseService(IUnitOfWork unitOfWork,
            IStatisticsSystem statisticsSystem,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _statisticsSystem = statisticsSystem;
            _logger = logger;
        }

        public async Task ExecuteAsync(Cartdrige cartdrige)
        {
            try
            {
                if (cartdrige == null) { throw new Exception("Error: El cartucho cuyo spot intenta revertirse tiene un valor nulo."); }

                await _unitOfWork.SpotRepository.Delete(cartdrige);

                await _statisticsSystem.WithdrawOneSpotGameBoyCartdrigeFromStatisticsAsync();

                string logEntry = $"REVERTIDO SPOT: Cartucho Game Boy. Id del juego: {cartdrige.IdGame}, Nombre: {cartdrige.Name}, " +
                    $"Fecha de spot: {cartdrige.PurchaseDate.ToString("yyyy-MM-dd")}, Precio de spot: {cartdrige.PurchasePrice}€";
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
