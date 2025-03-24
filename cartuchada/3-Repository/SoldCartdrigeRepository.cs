
using _1_Entities.Product_Entities;
using _1_Entities.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data.Models;
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
                .ToListAsync();

            return soldCartdrigeModels.Select(c => _mapper.Map<SoldCartdrige>(c));
        }

        public async Task AddAsync(SoldCartdrige soldCartdrige)
        {
            var soldCartdrigeModel = _mapper.Map<SoldCartdrigeModel>(soldCartdrige);

            await _context.SoldCartdriges.AddAsync(soldCartdrigeModel);
        }

        public Task Delete(SoldCartdrige cartdrige)
        {
            throw new NotImplementedException();
        }

        public Task<SoldCartdrige> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SoldCartdrige cartdrige)
        {
            throw new NotImplementedException();
        }
    }
}
