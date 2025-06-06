
using _3_Data.Models;
using _3_Data;
using AutoMapper;
using System.Linq.Expressions;
using _1_Domain.Product_Entities;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class FilterCartdrigeQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilterCartdrigeQuery(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cartdrige>> ExecuteQueryAsync(Expression<Func<CartdrigeModel, bool>> filter)
        {
            var filteredCartdrigeModels = await _context.Cartdriges
                .Where(filter)
                .ToListAsync();

            return filteredCartdrigeModels.Select(c => _mapper.Map<Cartdrige>(c));
        }
    }
}
