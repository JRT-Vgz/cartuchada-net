
namespace _2_Services.Interfaces
{
    public interface IStatisticsSystem
    {
        Task SumOnePurchasedGameBoyCartdrigeToStatisticsAsync();
        Task SumOnePurchasedGameBoyConsoleToStatisticsAsync();
        Task SumOneSpotGameBoyCartdrigeToStatisticsAsync();
        Task SumOneSoldGameBoyCartdrigeToStatisticsAsync();
    }
}
