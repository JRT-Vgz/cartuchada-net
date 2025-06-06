﻿using _1_Domain.Constants;
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

        private async Task SumToStatistic(string shopStatName, int quantity)
        {
            var shopStatModel = await _context.ShopStats.FirstOrDefaultAsync(s => s.Name == shopStatName);

            if (shopStatModel == null)
            {
                throw new StatisticSystemException($"No se encontró la estadística con el nombre '{shopStatName}' en la tabla 'shopStat'");
            }

            if (quantity <= 0) { throw new StatisticSystemException($"La cantidad a sumar no puede ser 0 ni negativa."); }

            shopStatModel.Quantity += quantity;

            try
            {
                _context.ShopStats.Update(shopStatModel);
            }
            catch (Exception)
            {
                throw new StatisticSystemException("Error al actualizar la estadística en la tabla 'ShopStat'");
            }
        }

        private async Task WithdrawFromStatistic(string shopStatName, int quantity)
        {
            var shopStatModel = await _context.ShopStats.FirstOrDefaultAsync(s => s.Name == shopStatName);

            if (shopStatModel == null)
            {
                throw new StatisticSystemException($"No se encontró la estadística con el nombre '{shopStatName}' en la tabla 'shopStat'");
            }

            if (quantity <= 0) { throw new StatisticSystemException($"La cantidad a sumar no puede ser 0 ni negativa."); }

            shopStatModel.Quantity -= quantity;

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
            await SumToStatistic(shopStatName, 1);
        }

        public async Task SumOnePurchasedConsoleToStatisticsAsync(int idProductType)
        {
            string shopStatName = string.Empty;
            if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE) { shopStatName = ShopStatConstants.GAME_BOY_COMPRADAS; }
            else if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE) { shopStatName = ShopStatConstants.GAME_GEAR_COMPRADAS; }

            await SumToStatistic(shopStatName, 1);
        }

        public async Task SumOneSpotGameBoyCartdrigeToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_SPOTEADOS;
            await SumToStatistic(shopStatName, 1);
        }

        public async Task SumOneSoldGameBoyCartdrigeToStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_VENDIDOS;
            await SumToStatistic(shopStatName, 1);
        }

        public async Task SumOneSoldConsoleToStatisticsAsync(int idProductType)
        {
            string shopStatName = string.Empty;
            if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE) { shopStatName = ShopStatConstants.GAME_BOY_VENDIDAS; }
            else if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE) { shopStatName = ShopStatConstants.GAME_GEAR_VENDIDAS; }

            await SumToStatistic(shopStatName, 1);
        }

        public async Task SumSoldSleevesToStatisticsAsync(int idSparePartType, int quantity)
        {
            string shopStatName = string.Empty;
            if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_BOY_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_PIRATA_GAME_BOY_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_GEAR_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_PIRATA_GAME_GEAR_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_BOY_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_ORIGINALES_GAME_BOY_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_GEAR_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_ORIGINALES_GAME_GEAR_VENDIDAS; }

            await SumToStatistic(shopStatName, quantity);
        }


        public async Task WithdrawOnePurchasedGameBoyCartdrigeFromStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_COMPRADOS;
            await WithdrawFromStatistic(shopStatName, 1);
        }

        public async Task WithdrawOnePurchasedConsoleFromStatisticsAsync(int idProductType)
        {
            string shopStatName = string.Empty;
            if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE) { shopStatName = ShopStatConstants.GAME_BOY_COMPRADAS; }
            else if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE) { shopStatName = ShopStatConstants.GAME_GEAR_COMPRADAS; }

            await WithdrawFromStatistic(shopStatName, 1);
        }

        public async Task WithdrawOneSpotGameBoyCartdrigeFromStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_SPOTEADOS;
            await WithdrawFromStatistic(shopStatName, 1);
        }

        public async Task WithdrawOneSoldGameBoyCartdrigeFromStatisticsAsync()
        {
            string shopStatName = ShopStatConstants.JUEGOS_GAME_BOY_VENDIDOS;
            await WithdrawFromStatistic(shopStatName, 1);
        }

        public async Task WithdrawOneSoldConsoleFromStatisticsAsync(int idProductType)
        {
            string shopStatName = string.Empty;
            if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE) { shopStatName = ShopStatConstants.GAME_BOY_VENDIDAS; }
            else if (idProductType == ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE) { shopStatName = ShopStatConstants.GAME_GEAR_VENDIDAS; }

            await WithdrawFromStatistic(shopStatName, 1);
        }

        public async Task WithdrawSoldSleevesFromStatisticsAsync(int idSparePartType, int quantity)
        {
            string shopStatName = string.Empty;
            if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_BOY_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_PIRATA_GAME_BOY_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_GEAR_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_PIRATA_GAME_GEAR_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_BOY_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_ORIGINALES_GAME_BOY_VENDIDAS; }
            else if (idSparePartType == SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_GEAR_SLEEVE)
            { shopStatName = ShopStatConstants.FUNDAS_ORIGINALES_GAME_GEAR_VENDIDAS; }

            await WithdrawFromStatistic(shopStatName, quantity);
        }
    }
}
