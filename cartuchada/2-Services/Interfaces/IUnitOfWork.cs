
using _1_Domain.Product_Entities;
using _1_Domain.Purchase_Entities;
using _1_Domain.Sold_Product_Entities;

namespace _2_Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Cartdrige> CartdrigeRepository { get; }
        public IRepository<VideoConsole> ConsoleRepository { get; }
        public IRepository<SparePartsPurchase> SparePartsPurchaseRepository { get; }
        public IRepository<Cartdrige> SpotRepository { get; }
        public IRepository<SoldCartdrige> SoldCartdrigeRepository { get; }
        public IRepository<SoldVideoConsole> SoldConsoleRepository { get; }
        public IRepository<SoldSleeve> SoldSleeveRepository { get; }

        public Task SaveChangesAsync();
    }
}
