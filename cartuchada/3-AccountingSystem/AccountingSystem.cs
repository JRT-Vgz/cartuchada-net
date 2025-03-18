using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models;
using _3_Data.Models.Management_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _3_AccountingSystem
{
    public class AccountingSystem : IAccountingSystem
    {
        private readonly AppDbContext _context;
        public AccountingSystem(AppDbContext context)
        {
            _context = context;
        }

        public async Task SumPurchasePriceToExpenses(DateTime dateTime, decimal purchasePrice)
        {
            // Busca el modelo de contabilidad para el año y mes de la fecha de compra.
            var accountingModel = await _context.Accounting
                .Where(a => a.Date.Year == dateTime.Year && a.Date.Month == dateTime.Month)
                .FirstOrDefaultAsync();

            // Si no existe el modelo, crea una entrada para el año y mes actuales.
            if (accountingModel == null) 
            {
                try { accountingModel = CreateAccountingEntryForCurrentDate(dateTime); }
                catch (Exception) { throw new AccountingSystemException("Error al crear una nueva entrada en la tabla 'Accounting'."); }
            }

            // Añade el gasto y actualiza.
            accountingModel.Expenses += purchasePrice;

            try { _context.Accounting.Update(accountingModel); }
            catch (Exception) { throw new AccountingSystemException("Error al actualizar las cuentas en la tabla 'Accounting'."); }
        }

        private AccountingModel CreateAccountingEntryForCurrentDate(DateTime dateTime) 
        {
            DateTime accountingDateFormat = new DateTime(dateTime.Year, dateTime.Month, 1);

            return new AccountingModel() { Date = accountingDateFormat, Income = 0, Expenses = 0 };
        }
    }
}
