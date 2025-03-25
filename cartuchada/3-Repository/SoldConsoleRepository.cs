
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data.Models.SaleModels;
using _3_Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class SoldConsoleRepository : IRepository<SoldVideoConsole>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SoldConsoleRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SoldVideoConsole>> GetAllAsync()
        {
            var soldConsoleModels = await _context.SoldConsoles
                .Include("ProductType")
                .ToListAsync();

            return soldConsoleModels.Select(c => _mapper.Map<SoldVideoConsole>(c));
        }

        public async Task<SoldVideoConsole> GetByIdAsync(int id)
        {
            var soldConsoleModel = await _context.SoldConsoles
                .Include("ProductType")
                .FirstOrDefaultAsync();

            return _mapper.Map<SoldVideoConsole>(soldConsoleModel);
        }

        public async Task AddAsync(SoldVideoConsole soldVideoConsole)
        {
            var soldConsoleModel = _mapper.Map<SoldConsoleModel>(soldVideoConsole);

            await _context.SoldConsoles.AddAsync(soldConsoleModel);
        }

        public async Task Delete(SoldVideoConsole soldVideoConsole)
        {
            var soldVideoConsoleModel = await _context.SoldConsoles.FirstOrDefaultAsync(c => c.Id == soldVideoConsole.Id);

            if (soldVideoConsoleModel == null) { return; }

            _context.SoldConsoles.Remove(soldVideoConsoleModel);
        }
    }
}
