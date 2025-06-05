
using _3_Data;
using _3_Data.Models.Spare_Parts_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class GetAllSparePartTypesQuery
    {
        private readonly AppDbContext _context;

        public GetAllSparePartTypesQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SparePartTypeModel>> ExecuteQueryAsync()
        {
            var sparePartTypes = await _context.SparePartTypes
                .ToListAsync();

            return sparePartTypes;
        }
    }
}
