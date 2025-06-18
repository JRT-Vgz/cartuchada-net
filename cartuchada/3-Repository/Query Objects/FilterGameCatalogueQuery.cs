using _3_Data;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class FilterGameCatalogueQuery
    {
        private readonly AppDbContext _context;

        public FilterGameCatalogueQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameCatalogueModel>> ExecuteQueryAsync(string searchFilter)
        {
            var games = await _context.Games
                .Include("ProductType")
                .Where(g => g.Name.Contains(searchFilter))
                .ToListAsync();

            return games;
        }
    }
}
