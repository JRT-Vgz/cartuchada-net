
namespace _2_Services.Interfaces
{
    public interface IPresenter<TInput, TOutput>
    {
        TOutput Present(TInput input);
    }
}
