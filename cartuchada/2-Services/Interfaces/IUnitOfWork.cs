
using _1_Entities.Product_Entities;
using _1_Entities.Purchase_Entities;
using _1_Entities.Sold_Product_Entities;

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

        public Task SaveChangesAsync();
    }
}
