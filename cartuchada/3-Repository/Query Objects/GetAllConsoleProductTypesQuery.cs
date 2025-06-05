
using _3_Data.Models;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllConsoleProductTypesQuery
    {
        private readonly AppDbContext _context;

        public GetAllConsoleProductTypesQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductTypeModel>> ExecuteQueryAsync()
        {
            var consoles = await _context.ProductTypes
                .Where(c => c.Name.Contains("Videoconsola"))
                .ToListAsync();

            return consoles;
        }
    }
}
