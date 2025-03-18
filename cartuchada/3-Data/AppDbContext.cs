using _3_Data.Models;
using _3_Data.Models.Management_Models;
using _3_Data.Models.Product_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductTypeModel> ProductTypes { get; set; }
        public DbSet<SystemModel> Systems { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
        public DbSet<ConditionModel> Conditions { get; set; }
        public DbSet<GameCatalogueModel> Games { get; set; }
        public DbSet<CartdrigeModel> Cartdriges { get; set; }
        public DbSet<ConsoleModel> Consoles { get; set; }
        public DbSet<SleeveModel> Sleeves { get; set; }
        public DbSet<ReferenceModel> References { get; set; }
        public DbSet<ShopStatModel> ShopStats { get; set; }
        public DbSet<AccountingModel> Accounting { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeModel>().ToTable("ProductType");
            modelBuilder.Entity<SystemModel>().ToTable("System");
            modelBuilder.Entity<RegionModel>().ToTable("Region");
            modelBuilder.Entity<ConditionModel>().ToTable("Condition");
            modelBuilder.Entity<GameCatalogueModel>().ToTable("GameCatalogue");
            modelBuilder.Entity<SleeveModel>().ToTable("Sleeve");
            modelBuilder.Entity<CartdrigeModel>().ToTable("Cartdrige");
            modelBuilder.Entity<ConsoleModel>().ToTable("Console");
            modelBuilder.Entity<ReferenceModel>().ToTable("Reference");
            modelBuilder.Entity<ShopStatModel>().ToTable("ShopStat");

            modelBuilder.Entity<GameCatalogueModel>()
                .HasOne(c => c.System)
                .WithMany()
                .HasForeignKey(c => c.IdSystem)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReferenceModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.Game)
                .WithMany()
                .HasForeignKey(c => c.IdGame)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
