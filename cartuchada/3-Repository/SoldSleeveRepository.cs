
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data.Models.SaleModels;
using _3_Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class SoldSleeveRepository : IRepository<SoldSleeve>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SoldSleeveRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SoldSleeve>> GetAllAsync()
        {
            var soldSleeveModels = await _context.SoldSleeves
                .Include("SparePartType")
                .ToListAsync();

            return soldSleeveModels.Select(c => _mapper.Map<SoldSleeve>(c));
        }

        public async Task AddAsync(SoldSleeve soldSleeve)
        {
            var soldSleeveModel = _mapper.Map<SoldSleeveModel>(soldSleeve);

            await _context.SoldSleeves.AddAsync(soldSleeveModel);
        }

        public Task Delete(SoldSleeve soldSleeve)
        {
            throw new NotImplementedException();
        }

        public Task<SoldSleeve> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SoldSleeve soldSleeve)
        {
            throw new NotImplementedException();
        }
    }
}
