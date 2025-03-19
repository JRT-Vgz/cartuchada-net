
using _1_Entities;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

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
                .Include("ProductType")
                .Include("Reference")
                .ToListAsync();

            return consoleModels.Select(c => _mapper.Map<VideoConsole>(c));
        }
        public async Task<VideoConsole> GetByIdAsync(int id)
        {
            var consoleModel = await _context.Consoles
                .Include("ProductType")
                .Include("Reference")
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<VideoConsole>(consoleModel);
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

        public async void Update(VideoConsole console)
        {
            var consoleModel = await _context.Consoles.FindAsync(console.Id);

            if (consoleModel == null) { throw new KeyNotFoundException($"No se ha encontrado ningún elemento con Id {console.Id} en la tabla 'Console'."); }

            _mapper.Map(console, consoleModel);

            _context.Consoles.Attach(consoleModel);
            _context.Consoles.Entry(consoleModel).State = EntityState.Modified;
        }
    }
}
