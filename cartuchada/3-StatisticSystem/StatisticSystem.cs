using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_StatisticSystem
{
    public class StatisticSystem : IStatisticsSystem
    {
        private readonly AppDbContext _context;
        public StatisticSystem(AppDbContext context)
        {
            _context = context;
        }

        public async Task SumStatistic(string shopStatName)
        {
            var shopStatModel = await _context.ShopStats.FirstOrDefaultAsync(s => s.Name == shopStatName);

            if (shopStatModel == null)
            {
                throw new StatisticSystemException($"No se encontró la estadística con el nombre '{shopStatName}' en la tabla 'shopStat'");
            }

            shopStatModel.Quantity += 1;

            try
            {
                _context.ShopStats.Update(shopStatModel);
            }
            catch (Exception)
            {
                throw new StatisticSystemException("Error al actualizar la estadística en la tabla 'ShopStat'");
            }
        }

        public async Task SumOnePurchasedGameBoyCartdrigeToStatistics()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_COMPRADOS;
            await SumStatistic(shopStatName);
        }

        public async Task SumOnePurchasedGameBoyConsoleToStatistics()
        {
            string shopStatName = ShopStatConstants.GAME_BOY_COMPRADAS;
            await SumStatistic(shopStatName);
        }
    }
}
