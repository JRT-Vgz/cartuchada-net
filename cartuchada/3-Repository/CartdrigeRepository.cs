using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class CartdrigeRepository : IRepository<Cartdrige>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CartdrigeRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cartdrige>> GetAllAsync()
        {
            var cartdrigeModels = await _context.Cartdriges
                .Include("Game")
                .Include("Reference")
                .ToListAsync();

            return cartdrigeModels.Select(c => _mapper.Map<Cartdrige>(c));
        }

        public async Task<Cartdrige> GetByIdAsync(int id)
        {
            var cartdrigeModel = await _context.Cartdriges
                .Include("Game")
                .Include("Reference")
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<Cartdrige>(cartdrigeModel);
        }

        public async Task AddAsync(Cartdrige cartdrige)
        {
            var cartdrigeModel = _mapper.Map<CartdrigeModel>(cartdrige);

            await _context.Cartdriges.AddAsync(cartdrigeModel);
        }

        public async Task Delete(Cartdrige cartdrige)
        {
            var cartdrigeModel = await _context.Cartdriges.FirstOrDefaultAsync(c => c.Id == cartdrige.Id);

            if (cartdrigeModel == null) { return; }

            _context.Cartdriges.Remove(cartdrigeModel);
        }
    }
}
