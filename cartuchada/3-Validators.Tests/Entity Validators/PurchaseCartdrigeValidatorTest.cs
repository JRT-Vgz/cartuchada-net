using _1_Domain.Product_Entities;
using _3_Data;
using _3_Data.Models;
using _3_Validators.Entity_Validators;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Tests.Entity_Validators
{
    public class PurchaseCartdrigeValidatorTest
    {
        private readonly AppDbContext _context;
        public PurchaseCartdrigeValidatorTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            _context = new AppDbContext(options);

            _context.ProductTypes.Add(new ProductTypeModel() { Id = 1, Name = "Product Type 1", ReferencePrefix = "Reference Prefix 1" });
            _context.Games.Add(new GameCatalogueModel() { Id = 1, IdProductType = 1, Name = "Game 1", JAP = true, NA = true, PAL = true });
            _context.Regions.Add(new RegionModel() { Id = 1, Name = "Region 1" });
            _context.Conditions.Add(new ConditionModel() { Id = 1, Name = "Condition 1" });
            _context.SaveChanges();
        }

        [Fact]
        public async Task When_ValidCartdrige_Expect_ValidationSuccess()
        {
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


            PurchasedCartdrigeValidator sut = new(_context);
            bool result = await sut.ValidateProductAsync(cartdrige);


            Assert.True(result);
            Assert.Empty(sut.Errors);
        }

        [Fact]
        public async Task When_InvalidProductType_Expect_ValidationFail()
        {
            int id = 1;
            int idReference = 1;
            int idProductType = 5; // IdProductType no corresponde con ningún tipo de producto
            int idGame = 1;
            int idRegion = 1;
            int idCondition = 1;
            DateTime purchaseDate = new DateTime(1984, 11, 27).Date;
            decimal purchasePrice = 10.50m;
            string name = "Cardrige 1";
            string reference = "Reference 1";

            Cartdrige cartdrige = new(id, idReference, idProductType, idGame, idRegion, idCondition,
                purchaseDate, purchasePrice, name, reference);


            PurchasedCartdrigeValidator sut = new(_context);
            bool result = await sut.ValidateProductAsync(cartdrige);


            Assert.False(result);
            Assert.Equal(2, sut.Errors.Count());
            Assert.Equal("No existe ningún tipo de producto con Id 5 en la tabla 'ProductType'.", sut.Errors[0]);
            Assert.Equal("El tipo de producto con Id 5 en la tabla 'ProductType' no corresponde con ningún cartucho.", sut.Errors[1]);
        }

        [Theory]
        [InlineData(0, 1, 1, 1, "Referencia 1")] // IdReference es 0.
        [InlineData(1, 5, 1, 1, "Referencia 1")] // IdGame no corresponde con ningun juego del catálogo.
        [InlineData(1, 1, 5, 1, "Referencia 1")] // IdRegion no corresponde con ninguna región válida.
        [InlineData(1, 1, 1, 5, "Referencia 1")] // IdCondition no corresponde con ninguna condición válida.
        [InlineData(1, 1, 1, 1, null)]           // Reference no está asignado.
        public async Task When_InvalidCartdrige_Expect_ValidationFail(int idReference, int idGame, int idRegion,
            int idCondition, string reference)
        {
            int id = 1;
            int idProductType = 1;
            DateTime purchaseDate = new DateTime(1984, 11, 27).Date;
            decimal purchasePrice = 10.50m;
            string name = "Cartucho 1";

            Cartdrige cartdrige = new(id, idReference, idProductType, idGame, idRegion, idCondition,
                purchaseDate, purchasePrice, name, reference);


            PurchasedCartdrigeValidator sut = new(_context);
            bool result = await sut.ValidateProductAsync(cartdrige);


            Assert.False(result);
            Assert.Single(sut.Errors);
        }
    }
}
