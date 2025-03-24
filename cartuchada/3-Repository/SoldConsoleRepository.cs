
using _1_Entities.Sold_Product_Entities;
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

        public async Task AddAsync(SoldVideoConsole soldVideoConsole)
        {
            var soldConsoleModel = _mapper.Map<SoldConsoleModel>(soldVideoConsole);

            await _context.SoldConsoles.AddAsync(soldConsoleModel);
        }

        public Task Delete(SoldVideoConsole soldVideoConsole)
        {
            throw new NotImplementedException();
        }

        public Task<SoldVideoConsole> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SoldVideoConsole soldVideoConsole)
        {
            throw new NotImplementedException();
        }
    }
}
