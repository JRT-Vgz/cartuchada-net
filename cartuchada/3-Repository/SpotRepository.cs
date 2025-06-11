using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models.Product_Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class SpotRepository : IRepository<Cartdrige>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SpotRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cartdrige>> GetAllAsync()
        {
            var spotModels = await _context.Spots
                .Include("Game")
                .Include("Region")
                .Include("Condition")
                .ToListAsync();

            return spotModels.Select(c => _mapper.Map<Cartdrige>(c));
        }
        public async Task<Cartdrige> GetByIdAsync(int id)
        {
            var spotModel = await _context.Spots
                .Include("Game")
                .Include("Region")
                .Include("Condition")
                .FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<Cartdrige>(spotModel);
        }

        public async Task AddAsync(Cartdrige cartdrige)
        {
            var spotModel = _mapper.Map<SpotModel>(cartdrige);

            await _context.Spots.AddAsync(spotModel);
        }

        public async Task Delete(Cartdrige cartdrige)
        {
            var spotModel = await _context.Spots
                .Where(s => s.IdProductType == cartdrige.IdProductType 
                    && s.IdGame == cartdrige.IdGame
                    && s.IdRegion == cartdrige.IdRegion
                    && s.IdCondition == cartdrige.IdCondition
                    && s.SpotDate == cartdrige.PurchaseDate
                    && s.SpotPrice == cartdrige.PurchasePrice)
                .FirstOrDefaultAsync();

            if (spotModel == null) { throw new Exception($"No se ha encontrado ningún cartucho en la tabla 'Spot' " +
                $"que cumpla con todas las condiciones descritas."); }

            _context.Spots.Remove(spotModel);
        }
    }
}
