using _2_Services.Exceptions;
using _3_AccountingSystem;
using _3_Data;
using _3_Data.Models.Management_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_AccountingSystemTests
{
    public class AccountingSystemTest
    {
        private readonly AppDbContext _context;
        public AccountingSystemTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            _context = new AppDbContext(options);
        }

        [Fact]
        public async Task SumPurchasePriceToExpensesAsync_When_AccountingEntryExists_Expect_ExpensesUpdatedSuccessfully()
        {
            _context.Accounting.Add(new AccountingModel() { Id = 1, Date = DateTime.Now.Date, Income = 50, Expenses = 100 });
            _context.SaveChanges();

            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.SumPurchasePriceToExpensesAsync(dateTime, purchasePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(110.50m, resultModel.Expenses);
        }

        [Fact]
        public async Task SumPurchasePriceToExpensesAsync_When_AccountingEntryDoesntExist_Expect_CreateEntryAndUpdateSuccessfully()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.SumPurchasePriceToExpensesAsync(dateTime, purchasePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(10.50m, resultModel.Expenses);
        }

        [Fact]
        public async Task SumPurchasePriceToExpensesAsync_When_NegativePurchasePrice_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = -10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.SumPurchasePriceToExpensesAsync(dateTime, purchasePrice));
            Assert.Contains("La cantidad a sumar no puede ser negativa.", resultException.Message);
        }

        [Fact]
        public async Task SumSalePriceToIncomeAsync_When_AccountingEntryExists_Expect_IncomeUpdatedSuccessfully()
        {
            _context.Accounting.Add(new AccountingModel() { Id = 1, Date = DateTime.Now.Date, Income = 50, Expenses = 100 });
            _context.SaveChanges();

            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.SumSalePriceToIncomeAsync(dateTime, salePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(60.50m, resultModel.Income);
        }

        [Fact]
        public async Task SumSalePriceToIncomeAsync_When_AccountingEntryDoesntExist_Expect_CreateEntryAndUpdateSuccessfully()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.SumSalePriceToIncomeAsync(dateTime, salePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(10.50m, resultModel.Income);
        }

        [Fact]
        public async Task SumSalePriceToIncomeAsync_When_NegativeSalePrice_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = -10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.SumSalePriceToIncomeAsync(dateTime, salePrice));
            Assert.Contains("La cantidad a sumar no puede ser negativa.", resultException.Message);
        }

        [Fact]
        public async Task WithdrawPurchasePriceFromExpensesAsync_When_AccountingEntryExists_Expect_ExpensesUpdatedSuccessfully()
        {
            _context.Accounting.Add(new AccountingModel() { Id = 1, Date = DateTime.Now.Date, Income = 50, Expenses = 100 });
            _context.SaveChanges();

            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.WithdrawPurchasePriceFromExpensesAsync(dateTime, purchasePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(89.50m, resultModel.Expenses);
        }

        [Fact]
        public async Task WithdrawPurchasePriceFromExpensesAsync_When_AccountingEntryDoesntExist_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = 10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.WithdrawPurchasePriceFromExpensesAsync(dateTime, purchasePrice));
            Assert.Contains("No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.", resultException.Message);
        }

        [Fact]
        public async Task WithdrawPurchasePriceFromExpensesAsync_When_NegativePurchasePrice_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal purchasePrice = -10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.WithdrawPurchasePriceFromExpensesAsync(dateTime, purchasePrice));
            Assert.Contains("La cantidad a restar no puede ser negativa.", resultException.Message);
        }

        [Fact]
        public async Task WithdrawSalePriceFromIncomeAsync_When_AccountingEntryExists_Expect_IncomeUpdatedSuccessfully()
        {
            _context.Accounting.Add(new AccountingModel() { Id = 1, Date = DateTime.Now.Date, Income = 50, Expenses = 100 });
            _context.SaveChanges();

            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = 10.50m;

            AccountingSystem sut = new(_context);
            await sut.WithdrawSalePriceFromIncomeAsync(dateTime, salePrice);
            AccountingModel resultModel = _context.Accounting.Find(1);

            Assert.Equal(39.50m, resultModel.Income);
        }

        [Fact]
        public async Task WithdrawSalePriceFromIncomeAsync_When_AccountingEntryDoesntExist_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = 10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.WithdrawSalePriceFromIncomeAsync(dateTime, salePrice));
            Assert.Contains("No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.", resultException.Message);
        }

        [Fact]
        public async Task WithdrawSalePriceFromIncomeAsync_When_NegativeSalePrice_Expect_ThrowException()
        {
            DateTime dateTime = DateTime.Now.Date;
            decimal salePrice = -10.50m;

            AccountingSystem sut = new(_context);


            var resultException = await Assert.ThrowsAsync<AccountingSystemException>(
                () => sut.WithdrawSalePriceFromIncomeAsync(dateTime, salePrice));
            Assert.Contains("La cantidad a restar no puede ser negativa.", resultException.Message);
        }
    }
}
