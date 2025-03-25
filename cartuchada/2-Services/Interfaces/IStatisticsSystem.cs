
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
    }
}
