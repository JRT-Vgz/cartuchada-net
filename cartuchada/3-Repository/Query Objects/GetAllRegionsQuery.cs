
using _3_Data.Models;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllRegionsQuery
    {
        private readonly AppDbContext _context;

        public GetAllRegionsQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegionModel>> ExecuteQueryAsync()
        {
            var regions = await _context.Regions
                .ToListAsync();

            return regions;
        }
    }
}
