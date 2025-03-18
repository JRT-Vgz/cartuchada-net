
using _1_Entities;
using _2_Services.Interfaces;
using _3_Data;
using AutoMapper;

namespace _3_Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private IRepository<Cartdrige> _cartdrigeRepository;
        private IRepository<VideoConsole> _consoleRepository;

        public IRepository<Cartdrige> CartdrigeRepository
        {
            get
            {
                return _cartdrigeRepository == null ?
                    _cartdrigeRepository = new CartdrigeRepository(_context, _mapper) :
                    _cartdrigeRepository;
            }
        }

        public IRepository<VideoConsole> ConsoleRepository
        {
            get
            {
                return _consoleRepository == null? 
                    _consoleRepository = new ConsoleRepository(_context, _mapper) :
                    _consoleRepository;
            }
        }

        public UnitOfWork(AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
