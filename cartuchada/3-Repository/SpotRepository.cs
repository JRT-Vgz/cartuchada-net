using _1_Entities.Product_Entities;
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
                .ToListAsync();

            return spotModels.Select(c => _mapper.Map<Cartdrige>(c));
        }

        public async Task AddAsync(Cartdrige cartdrige)
        {
            var spotModel = _mapper.Map<SpotModel>(cartdrige);

            await _context.Spots.AddAsync(spotModel);
        }

        public void Delete(Cartdrige cartdrige)
        {
            throw new NotImplementedException();
        }

        public Task<Cartdrige> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cartdrige cartdrige)
        {
            throw new NotImplementedException();
        }
    }
}
