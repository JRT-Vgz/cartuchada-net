
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using _3_Data.Models.SaleModels;

namespace _3_Repository
{
    public class SoldCartdrigeRepository : IRepository<SoldCartdrige>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SoldCartdrigeRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SoldCartdrige>> GetAllAsync()
        {
            var soldCartdrigeModels = await _context.SoldCartdriges
                .Include("Game")
                .Include("Region")
                .Include("Condition")
                .ToListAsync();

            return soldCartdrigeModels.Select(c => _mapper.Map<SoldCartdrige>(c));
        }

        public async Task<SoldCartdrige> GetByIdAsync(int id)
        {
            var soldCartdrigeModel = await _context.SoldCartdriges
                .Include("Game")
                .Include("Region")
                .Include("Condition")
                .FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<SoldCartdrige>(soldCartdrigeModel);
        }

        public async Task AddAsync(SoldCartdrige soldCartdrige)
        {
            var soldCartdrigeModel = _mapper.Map<SoldCartdrigeModel>(soldCartdrige);

            await _context.SoldCartdriges.AddAsync(soldCartdrigeModel);
        }

        public async Task Delete(SoldCartdrige soldCartdrige)
        {
            var soldCartdrigeModel = await _context.SoldCartdriges.FirstOrDefaultAsync(c => c.Id == soldCartdrige.Id);

            if (soldCartdrigeModel == null) { throw new Exception($"No se ha encontrado ninguna venta de cartucho " +
                $"con Id {soldCartdrige.Id} en la tabla 'SoldCartdrige'."); }

            _context.SoldCartdriges.Remove(soldCartdrigeModel);
        }
    }
}
