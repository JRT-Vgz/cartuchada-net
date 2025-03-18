
using _1_Entities;

namespace _2_Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Cartdrige> CartdrigeRepository { get; }
        public IRepository<VideoConsole> ConsoleRepository { get; }
        public IRepository<SparePartsPurchase> SparePartsPurchaseRepository { get; }

        public Task SaveChangesAsync();
    }
}
