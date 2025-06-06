
using _3_Data.Models.Spare_Parts_Models;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllSleevesQuery
    {
        private readonly AppDbContext _context;

        public GetAllSleevesQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SparePartTypeModel>> ExecuteQueryAsync()
        {
            var sleeveModels = await _context.SparePartTypes
                .Where(s => s.Name.Contains("Fundas"))
                .ToListAsync();

            return sleeveModels;
        }
    }
}
