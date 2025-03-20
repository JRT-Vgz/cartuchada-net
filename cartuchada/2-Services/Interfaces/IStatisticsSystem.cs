
namespace _2_Services.Interfaces
{
    public interface IStatisticsSystem
    {
        Task SumOnePurchasedGameBoyCartdrigeToStatistics();
        Task SumOnePurchasedGameBoyConsoleToStatistics();
        Task SumOneSpotGameBoyCartdrigeToStatistics();
    }
}
