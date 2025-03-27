
using _1_Domain.Product_Entities;
using _3_Data;
using _3_Data.Models;
using _3_Validators.Entity_Validators;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Tests.Entity_Validators
{
    public class PurchaseCartdrigeValidatorTests
    {
        [Fact]
        public async Task When_CartdrigeCorrect_Expect_ValidationSuccess()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            AppDbContext context = new(options);

            context.ProductTypes.Add(new ProductTypeModel() { Id = 1, Name = "Product Type 1", ReferencePrefix = "Reference Prefix 1"});
            context.Games.Add(new GameCatalogueModel() { Id = 1, IdProductType = 1, Name = "Game 1", JAP = true, NA = true, PAL = true });
            context.Regions.Add(new RegionModel() { Id = 1, Name = "Region 1" });
            context.Conditions.Add(new ConditionModel() { Id = 1, Name = "Condition 1" });
            context.SaveChanges();

            int id = 1; 
            int idReference = 1;
            int idProductType = 1;
            int idGame = 1;
            int idRegion = 1;
            int idCondition = 1;
            DateTime purchaseDate = new DateTime(1984, 11, 27).Date;
            decimal purchasePrice = 10.50m;
            string name = "Cardrige 1";
            string reference = "Reference 1";

            Cartdrige cartdrige = new(id, idReference, idProductType, idGame, idRegion, idCondition, 
                purchaseDate, purchasePrice, name, reference);


            PurchasedCartdrigeValidator sut = new(context);

            bool result = await sut.ValidateProductAsync(cartdrige);


            Assert.True(result);
            Assert.Empty(sut.Errors);

        }
    }
}
