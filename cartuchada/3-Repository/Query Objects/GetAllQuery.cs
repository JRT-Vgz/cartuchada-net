
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllQuery<TModel> : IGetAllQuery<TModel> where TModel : class
    {
        private readonly AppDbContext _context;

        public GetAllQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TModel>> ExecuteQueryAsync()
            => await _context.Set<TModel>().ToListAsync();
    }
}
