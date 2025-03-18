
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace _3_Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            //var connectionString = "Connection string";
            var connectionString = "Server = localhost; Database = Cartuchada; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlServer(DBEncrypter.Decrypt(connectionString));
            optionsBuilder.UseSqlServer(connectionString);


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}