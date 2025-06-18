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
        public DbSet<WarningModel> Warnings { get; set; }
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



            // GAME CATALOGUE
            modelBuilder.Entity<GameCatalogueModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);


            // REFERENCE 
            modelBuilder.Entity<ReferenceModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);


            // CARTDRIGE
            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.Reference)
                .WithMany()
                .HasForeignKey(c => c.IdReference)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.Game)
                .WithMany()
                .HasForeignKey(c => c.IdGame)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.IdRegion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartdrigeModel>()
                .HasOne(c => c.Condition)
                .WithMany()
                .HasForeignKey(c => c.IdCondition)
                .OnDelete(DeleteBehavior.Restrict);


            //CONSOLE
            modelBuilder.Entity<ConsoleModel>()
                .HasOne(c => c.Reference)
                .WithMany()
                .HasForeignKey(c => c.IdReference)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsoleModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);


            // SPARE PARTS PURCHASE
            modelBuilder.Entity<SparePartsPurchaseModel>()
                .HasOne(s => s.SparePartType)
                .WithMany()
                .HasForeignKey(s => s.IdSparePartType)
                .OnDelete(DeleteBehavior.Restrict);


            // SOLD CARTDRIGE
            modelBuilder.Entity<SoldCartdrigeModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldCartdrigeModel>()
                .HasOne(c => c.Game)
                .WithMany()
                .HasForeignKey(c => c.IdGame)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldCartdrigeModel>()
                .HasOne(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.IdRegion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldCartdrigeModel>()
                .HasOne(c => c.Condition)
                .WithMany()
                .HasForeignKey(c => c.IdCondition)
                .OnDelete(DeleteBehavior.Restrict);


            // SOLD CONSOLE
            modelBuilder.Entity<SoldConsoleModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);


            // SOLD SLEEVE
            modelBuilder.Entity<SoldSleeveModel>()
                .HasOne(s => s.SparePartType)
                .WithMany()
                .HasForeignKey(s => s.IdSparePartType)
                .OnDelete(DeleteBehavior.Restrict);


            // SPOT
            modelBuilder.Entity<SpotModel>()
                .HasOne(c => c.ProductType)
                .WithMany()
                .HasForeignKey(c => c.IdProductType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpotModel>()
                .HasOne(c => c.Game)
                .WithMany()
                .HasForeignKey(c => c.IdGame)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpotModel>()
                .HasOne(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.IdRegion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpotModel>()
                .HasOne(c => c.Condition)
                .WithMany()
                .HasForeignKey(c => c.IdCondition)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ProtectNonDeletableModels(List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> deletedEntities)
        {
            foreach (var entity in deletedEntities)
            {
                if (entity.Entity is GameCatalogueModel
                    || entity.Entity is ReferenceModel
                    || entity.Entity is ProductTypeModel
                    || entity.Entity is RegionModel
                    || entity.Entity is ConditionModel
                    || entity.Entity is SparePartTypeModel
                    || entity.Entity is ShopStatModel
                    || entity.Entity is AccountingModel
                    || entity.Entity is WarningModel
                    || entity.Entity is LogModel)
                {
                    entity.State = EntityState.Unchanged;

                    string warningEntry = $"DELETE WRN: Se ha intentado borrar una entrada del tipo '{entity.Entity.GetType().Name}'.";
                    var warningModel = new WarningModel() { Date = DateTime.Now, Entry = warningEntry };
                    this.Warnings.AddAsync(warningModel);
                }
            }
        }

        public override int SaveChanges()
        {
            var deletedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            ProtectNonDeletableModels(deletedEntities);

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var deletedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            ProtectNonDeletableModels(deletedEntities);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
