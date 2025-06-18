using _1_Domain.Product_Entities;
using _3_Data;
using _3_Data.Models.Product_Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _3_Repository.Query_Objects
{
    public class FilterSpotedCartdrigeQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilterSpotedCartdrigeQuery(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cartdrige>> ExecuteQueryAsync(Expression<Func<SpotModel, bool>> filter)
        {
            var filteredSpotedCartdrigeModels = await _context.Spots
                .Include("Region")
                .Include("Condition")
                .Where(filter)
                .ToListAsync();

            return filteredSpotedCartdrigeModels.Select(c => _mapper.Map<Cartdrige>(c));
        }
    }
}
