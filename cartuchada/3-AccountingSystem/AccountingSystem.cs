using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models.Management_Models;
using Microsoft.EntityFrameworkCore;

namespace _3_AccountingSystem
{
    public class AccountingSystem : IAccountingSystem
    {
        private readonly AppDbContext _context;
        public AccountingSystem(AppDbContext context)
        {
            _context = context;
        }

        public async Task SumPurchasePriceToExpensesAsync(DateTime dateTime, decimal purchasePrice)
        {
            if (purchasePrice < 0) { throw new AccountingSystemException($"La cantidad a sumar no puede ser negativa."); }

            var accountingModel = await GetAccountingEntryAsync(dateTime);

            if (accountingModel == null)
            {
                try { accountingModel = CreateNewAccountingEntryForCurrentDate(dateTime); }
                catch (Exception) { throw new AccountingSystemException("Error al crear una nueva entrada en la tabla 'Accounting'."); }
            }

            accountingModel.Expenses += purchasePrice;

            UpdateAccountingDatabase(accountingModel);
        }

        public async Task SumSalePriceToIncomeAsync(DateTime dateTime, decimal salePrice)
        {
            if (salePrice < 0) { throw new AccountingSystemException($"La cantidad a sumar no puede ser negativa."); }

            var accountingModel = await GetAccountingEntryAsync(dateTime);

            if (accountingModel == null)
            {
                try { accountingModel = CreateNewAccountingEntryForCurrentDate(dateTime); }
                catch (Exception) { throw new AccountingSystemException("Error al crear una nueva entrada en la tabla 'Accounting'."); }
            }

            accountingModel.Income += salePrice;

            UpdateAccountingDatabase(accountingModel);
        }

        public async Task WithdrawPurchasePriceFromExpensesAsync(DateTime dateTime, decimal purchasePrice)
        {
            if (purchasePrice < 0) { throw new AccountingSystemException($"La cantidad a restar no puede ser negativa."); }

            var accountingModel = await GetAccountingEntryAsync(dateTime);

            if (accountingModel == null)
            { 
                throw new AccountingSystemException($"No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.");
            }

            accountingModel.Expenses -= purchasePrice;

            UpdateAccountingDatabase(accountingModel);
        }

        public async Task WithdrawSalePriceFromIncomeAsync(DateTime dateTime, decimal salePrice)
        {
            if (salePrice < 0) { throw new AccountingSystemException($"La cantidad a restar no puede ser negativa."); }

            var accountingModel = await GetAccountingEntryAsync(dateTime);

            if (accountingModel == null)
            {
                throw new AccountingSystemException($"No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.");
            }

            accountingModel.Income -= salePrice;

            UpdateAccountingDatabase(accountingModel);
        }

        private async Task<AccountingModel> GetAccountingEntryAsync(DateTime dateTime)
        {
            var accountingModel = await _context.Accounting
                .Where(a => a.Date.Year == dateTime.Year && a.Date.Month == dateTime.Month)
                .FirstOrDefaultAsync();

            return accountingModel;
        }

        private AccountingModel CreateNewAccountingEntryForCurrentDate(DateTime dateTime)
        {
            DateTime accountingDateFormat = new DateTime(dateTime.Year, dateTime.Month, 1);

            return new AccountingModel() { Date = accountingDateFormat, Income = 0, Expenses = 0 };
        }

        private void UpdateAccountingDatabase(AccountingModel accountingModel)
        {
            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }
    }
}
