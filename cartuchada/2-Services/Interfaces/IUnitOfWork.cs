
using _1_Entities;

namespace _2_Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Cartdrige> CartdrigeRepository { get; }
        public IRepository<VideoConsole> ConsoleRepository { get; }

        public Task SaveChangesAsync();
    }
}
