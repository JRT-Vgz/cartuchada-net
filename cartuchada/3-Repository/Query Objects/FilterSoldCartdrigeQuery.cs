using _1_Domain.Sold_Product_Entities;
using _3_Data;
using _3_Data.Models.SaleModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _3_Repository.Query_Objects
{
    public class FilterSoldCartdrigeQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilterSoldCartdrigeQuery(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SoldCartdrige>> ExecuteQueryAsync(Expression<Func<SoldCartdrigeModel, bool>> filter)
        {
            var filteredSoldCartdrigeModels = await _context.SoldCartdriges
                .Include("Region")
                .Include("Condition")
                .Where(filter)
                .ToListAsync();

            return filteredSoldCartdrigeModels.Select(c => _mapper.Map<SoldCartdrige>(c));
        }
    }
}
