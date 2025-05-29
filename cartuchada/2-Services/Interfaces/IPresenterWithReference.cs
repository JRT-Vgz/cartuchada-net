
namespace _2_Services.Interfaces
{
    public interface IPresenterWithReference<TInput, TOutput>
    {
        TOutput Present(TInput input, string reference);
    }
}
