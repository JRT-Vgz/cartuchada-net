
namespace _2_Services.Interfaces
{
    public interface IManualMapper<TInput, TOutput>
    {
        TOutput Map(TInput input);
    }
}
