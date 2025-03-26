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

            var accountingModel = await GetOrCreateAccountingEntryAsync(dateTime);

            accountingModel.Expenses += purchasePrice;

            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }

        public async Task SumSalePriceToIncomeAsync(DateTime dateTime, decimal salePrice)
        {
            if (salePrice < 0) { throw new AccountingSystemException($"La cantidad a sumar no puede ser negativa."); }

            var accountingModel = await GetOrCreateAccountingEntryAsync(dateTime);

            accountingModel.Income += salePrice;

            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }

        private async Task<AccountingModel> GetOrCreateAccountingEntryAsync(DateTime dateTime)
        {
            var accountingModel = await _context.Accounting
                .Where(a => a.Date.Year == dateTime.Year && a.Date.Month == dateTime.Month)
                .FirstOrDefaultAsync();

            if (accountingModel == null)
            {
                try { accountingModel = CreateNewAccountingEntryForCurrentDate(dateTime); }
                catch (Exception) { throw new AccountingSystemException("Error al crear una nueva entrada en la tabla 'Accounting'."); }
            }

            return accountingModel;
        }

        private AccountingModel CreateNewAccountingEntryForCurrentDate(DateTime dateTime)
        {
            DateTime accountingDateFormat = new DateTime(dateTime.Year, dateTime.Month, 1);

            return new AccountingModel() { Date = accountingDateFormat, Income = 0, Expenses = 0 };
        }


        public async Task WithdrawPurchasePriceFromExpensesAsync(DateTime dateTime, decimal purchasePrice)
        {
            if (purchasePrice < 0) { throw new AccountingSystemException($"La cantidad a restar no puede ser negativa."); }

            var accountingModel = await _context.Accounting
                .Where(a => a.Date.Year == dateTime.Year && a.Date.Month == dateTime.Month)
                .FirstOrDefaultAsync();

            if (accountingModel == null)
            { 
                throw new AccountingSystemException($"No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.");
            }

            accountingModel.Expenses -= purchasePrice;

            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }

        public async Task WithdrawSalePriceFromIncomeAsync(DateTime dateTime, decimal salePrice)
        {
            if (salePrice < 0) { throw new AccountingSystemException($"La cantidad a restar no puede ser negativa."); }

            var accountingModel = await _context.Accounting
                .Where(a => a.Date.Year == dateTime.Year && a.Date.Month == dateTime.Month)
                .FirstOrDefaultAsync();

            if (accountingModel == null)
            {
                throw new AccountingSystemException($"No se ha encontrado una entrada para la fecha " +
                    $"{dateTime.Year}-{dateTime.Month}-01 en la tabla 'Accounting'.");
            }

            accountingModel.Income -= salePrice;

            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }
    }
}
