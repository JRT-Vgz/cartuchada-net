
using _1_Entities;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository
{
    public class ConsoleRepository : IRepository<VideoConsole>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ConsoleRepository(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VideoConsole>> GetAllAsync()
        {
            var consoleModels = await _context.Consoles
                .Include("System")
                .Include("Reference")
                .ToListAsync();

            return consoleModels.Select(c => _mapper.Map<VideoConsole>(c));
        }

        public async Task AddAsync(VideoConsole console)
        {
            var consoleModel = _mapper.Map<ConsoleModel>(console);

            await _context.Consoles.AddAsync(consoleModel);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VideoConsole> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(VideoConsole entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
