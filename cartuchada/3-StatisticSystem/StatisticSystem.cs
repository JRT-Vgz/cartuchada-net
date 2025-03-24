using _1_Domain.Constants;
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

        public async Task SumOneToStatistic(string shopStatName)
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

        public async Task SumOnePurchasedGameBoyCartdrigeToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_COMPRADOS;
            await SumOneToStatistic(shopStatName);
        }

        public async Task SumOnePurchasedGameBoyConsoleToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.GAME_BOY_COMPRADAS;
            await SumOneToStatistic(shopStatName);
        }

        public async Task SumOneSpotGameBoyCartdrigeToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_SPOTEADOS;
            await SumOneToStatistic(shopStatName);
        }

        public async Task SumOneSoldGameBoyCartdrigeToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_VENDIDOS;
            await SumOneToStatistic(shopStatName);
        }

        public async Task SumOneSoldConsoleToStatisticsAsync(int idProductType)
        {
            string shopStatName = string.Empty;
            if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE) { shopStatName = ShopStatConstants.GAME_BOY_VENDIDAS; }
            else if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE) { shopStatName = ShopStatConstants.GAME_GEAR_VENDIDAS; }

            await SumOneToStatistic(shopStatName);
        }
    }
}
