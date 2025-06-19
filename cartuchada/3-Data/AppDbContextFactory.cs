
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using _2_Services.Interfaces;

namespace _3_Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Connection string";
           
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            //optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));
            optionsBuilder.UseSqlServer(connectionString);


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}