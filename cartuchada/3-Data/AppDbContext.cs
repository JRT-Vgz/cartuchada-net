using _3_Data.Models;
using _3_Data.Models.Management_Models;
using _3_Data.Models.Product_Models;
using _3_Data.Models.SaleModels;
using _3_Data.Models.Spare_Parts_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductTypeModel> ProductTypes { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
        public DbSet<ConditionModel> Conditions { get; set; }
        public DbSet<GameCatalogueModel> Games { get; set; }
        public DbSet<CartdrigeModel> Cartdriges { get; set; }
        public DbSet<ConsoleModel> Consoles { get; set; }
        public DbSet<ReferenceModel> References { get; set; }
        public DbSet<ShopStatModel> ShopStats { get; set; }
        public DbSet<AccountingModel> Accounting { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<SparePartTypeModel> SparePartTypes { get; set; }
        public DbSet<SparePartsPurchaseModel> SparePartsPurchases { get; set; }
        public DbSet<SoldCartdrigeModel> SoldCartdriges { get; set; }
        public DbSet<SoldConsoleModel> SoldConsoles { get; set; }
        public DbSet<SoldSleeveModel> SoldSleeves { get; set; }
        public DbSet<SpotModel> Spots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeModel>().ToTable("ProductType");
            modelBuilder.Entity<RegionModel>().ToTable("Region");
            modelBuilder.Entity<ConditionModel>().ToTable("Condition");
            modelBuilder.Entity<GameCatalogueModel>().ToTable("GameCatalogue");
            modelBuilder.Entity<CartdrigeModel>().ToTable("Cartdrige");
            modelBuilder.Entity<ConsoleModel>().ToTable("Console");
            modelBuilder.Entity<ReferenceModel>().ToTable("Reference");
            modelBuilder.Entity<ShopStatModel>().ToTable("ShopStat");
            modelBuilder.Entity<SparePartTypeModel>().ToTable("SparePartType");
            modelBuilder.Entity<SparePartsPurchaseModel>().ToTable("SparePartsPurchase");
            modelBuilder.Entity<SoldCartdrigeModel>().ToTable("SoldCartdrige");
            modelBuilder.Entity<SoldConsoleModel>().ToTable("SoldConsole");
            modelBuilder.Entity<SoldSleeveModel>().ToTable("SoldSleeve");
            modelBuilder.Entity<SpotModel>().ToTable("Spot");

            modelBuilder.Entity<GameCatalogueModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
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

            //modelBuilder.Entity<CartdrigeModel>()
            //    .HasOne(c => c.ProductType)
            //    .WithMany()
            //    .HasForeignKey(c => c.IdProductType)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<CartdrigeModel>()
            //    .HasOne(c => c.Reference)
            //    .WithMany()
            //    .HasForeignKey(c => c.IdReference)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SoldCartdrigeModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
