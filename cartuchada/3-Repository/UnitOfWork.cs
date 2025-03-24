using _1_Entities.Product_Entities;
using _1_Entities.Purchase_Entities;
using _1_Entities.Sold_Product_Entities;
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
        private IRepository<SparePartsPurchase> _sparePartsPurchaseRepository;
        private IRepository<Cartdrige> _spotRepository;
        private IRepository<SoldCartdrige> _soldCartdrigeRepository;
        private IRepository<SoldVideoConsole> _soldConsoleRepository;

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
                return _consoleRepository == null ?
                    _consoleRepository = new ConsoleRepository(_context, _mapper) :
                    _consoleRepository;
            }
        }

        public IRepository<SparePartsPurchase> SparePartsPurchaseRepository
        {
            get
            {
                return _sparePartsPurchaseRepository == null ?
                    _sparePartsPurchaseRepository = new SparePartsPurchaseRepository(_context, _mapper) :
                    _sparePartsPurchaseRepository;
            }
        }

        public IRepository<Cartdrige> SpotRepository
        {
            get
            {
                return _spotRepository == null ?
                    _spotRepository = new SpotRepository(_context, _mapper) :
                    _spotRepository;
            }
        }

        public IRepository<SoldCartdrige> SoldCartdrigeRepository
        {
            get
            {
                return _soldCartdrigeRepository == null ?
                    _soldCartdrigeRepository = new SoldCartdrigeRepository(_context, _mapper) :
                    _soldCartdrigeRepository;
            }
        }

        public IRepository<SoldVideoConsole> SoldConsoleRepository
        {
            get
            {
                return _soldConsoleRepository == null ?
                    _soldConsoleRepository = new SoldConsoleRepository(_context, _mapper) :
                    _soldConsoleRepository;
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
