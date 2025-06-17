
using System.Linq.Expressions;

namespace _2_Services.Interfaces
{
    public interface IGetAllQuery<TModel>
    {
        Task<IEnumerable<TModel>> ExecuteQueryAsync();
    }
}
