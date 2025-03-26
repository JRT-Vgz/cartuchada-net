
namespace _2_Services.Interfaces
{
    public interface IStatisticsSystem
    {
        Task SumOnePurchasedGameBoyCartdrigeToStatisticsAsync();
        Task SumOnePurchasedConsoleToStatisticsAsync(int idProductType);
        Task SumOneSpotGameBoyCartdrigeToStatisticsAsync();
        Task SumOneSoldGameBoyCartdrigeToStatisticsAsync();
        Task SumOneSoldConsoleToStatisticsAsync(int idProductType);
        Task SumSoldSleevesToStatisticsAsync(int idSparePartType, int quantity);

        Task WithdrawOnePurchasedGameBoyCartdrigeFromStatisticsAsync();
        Task WithdrawOnePurchasedConsoleFromStatisticsAsync(int idProductType);
        Task WithdrawOneSpotGameBoyCartdrigeFromStatisticsAsync();
        Task WithdrawOneSoldGameBoyCartdrigeFromStatisticsAsync();
        Task WithdrawOneSoldConsoleFromStatisticsAsync(int idProductType);
        Task WithdrawSoldSleevesFromStatisticsAsync(int idSparePartType, int quantity);

    }
}
