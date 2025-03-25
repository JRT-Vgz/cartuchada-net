using _1_Domain.Purchase_Entities;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models.Spare_Parts_Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class SparePartsPurchaseRepository : IRepository<SparePartsPurchase>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SparePartsPurchaseRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SparePartsPurchase>> GetAllAsync()
        {
            var sparePartsPurchaseModels = await _context.SparePartsPurchases
                .Include("SparePartType")
                .ToListAsync();

            return sparePartsPurchaseModels.Select(c => _mapper.Map<SparePartsPurchase>(c));
        }

        public async Task<SparePartsPurchase> GetByIdAsync(int id)
        {
            var sparePartsPurchaseModel = await _context.SparePartsPurchases
                .Include("SparePartType")
                .FirstOrDefaultAsync();

            return _mapper.Map<SparePartsPurchase>(sparePartsPurchaseModel);
        }

        public async Task AddAsync(SparePartsPurchase sparePartsPurchase)
        {
            var sparePartsPurchaseModel = _mapper.Map<SparePartsPurchaseModel>(sparePartsPurchase);

            await _context.SparePartsPurchases.AddAsync(sparePartsPurchaseModel);
        }

        public async Task Delete(SparePartsPurchase sparePartsPurchase)
        {
            var sparePartsPurchaseModel = await _context.SparePartsPurchases.FirstOrDefaultAsync(c => c.Id == sparePartsPurchase.Id);

            if (sparePartsPurchaseModel == null) { return; }

            _context.SparePartsPurchases.Remove(sparePartsPurchaseModel);
        }
    }
}
