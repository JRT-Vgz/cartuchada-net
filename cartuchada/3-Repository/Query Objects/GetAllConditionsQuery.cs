
using _3_Data.Models;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllConditionsQuery
    {
        private readonly AppDbContext _context;

        public GetAllConditionsQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConditionModel>> ExecuteQueryAsync()
        {
            var conditions = await _context.Conditions
                .ToListAsync();

            return conditions;
        }
    }
}
