using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _1_Domain.Sold_Product_Entities;
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
        private IRepositoryUpdate<VideoConsole> _consoleRepositoryUpdate;
        private IRepository<SparePartsPurchase> _sparePartsPurchaseRepository;
        private IRepository<Cartdrige> _spotRepository;
        private IRepository<SoldCartdrige> _soldCartdrigeRepository;
        private IRepository<SoldVideoConsole> _soldConsoleRepository;
        private IRepository<SoldSleeve> _soldSleeveRepository;

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

        public IRepositoryUpdate<VideoConsole> ConsoleRepositoryUpdate
        {
            get
            {
                return _consoleRepositoryUpdate == null ?
                    _consoleRepositoryUpdate = (IRepositoryUpdate<VideoConsole>)ConsoleRepository :
                    _consoleRepositoryUpdate;
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

        public IRepository<SoldSleeve> SoldSleeveRepository
        {
            get
            {
                return _soldSleeveRepository == null ?
                    _soldSleeveRepository = new SoldSleeveRepository(_context, _mapper) :
                    _soldSleeveRepository;
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
