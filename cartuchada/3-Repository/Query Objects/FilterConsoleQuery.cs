
using _1_Domain.Product_Entities;
using _3_Data.Models;
using _3_Data;
using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Query_Objects
{
    public class FilterConsoleQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilterConsoleQuery(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VideoConsole>> ExecuteQueryAsync(Expression<Func<ConsoleModel, bool>> filter)
        {
            var filteredConsoleModels = await _context.Consoles
                .Where(filter)
                .ToListAsync();

            return filteredConsoleModels.Select(c => _mapper.Map<VideoConsole>(c));
        }
    }
}
