
using _1_Domain.Sold_Product_Entities;
using _1_Domain.Constants;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Entity_Validators
{
    public class SoldConsoleValidator : IProductValidator<SoldVideoConsole>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public SoldConsoleValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(SoldVideoConsole soldVideoConsole)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == soldVideoConsole.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {soldVideoConsole.IdProductType} en la tabla 'ProductType'."); }

            if (soldVideoConsole.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE &&
                soldVideoConsole.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE)
            {
                Errors.Add($"El tipo de producto con Id {soldVideoConsole.IdProductType} en la tabla 'ProductType' no corresponde con ninguna videoconsola.");
            }

            var consoleExists = await _context.Consoles.AnyAsync(c => c.Id == soldVideoConsole.IdConsole);
            if (!consoleExists) { Errors.Add($"No existe ninguna consola con Id {soldVideoConsole.IdConsole} en la tabla 'Console'."); }

            if (soldVideoConsole.PurchasePrice < 0) { Errors.Add("El campo 'PurchasePrice' no puede ser negativo."); }

            if (soldVideoConsole.SparePartsPrice < 0) { Errors.Add("El campo 'SalePartsPrice' no puede ser negativo."); }

            if (soldVideoConsole.TotalPrice < 0) { Errors.Add("El campo 'TotalPrice' no puede ser negativo."); }

            if (soldVideoConsole.SaleDate != DateTime.Now.Date) { Errors.Add("El campo 'SaleDate' no coincide con la fecha actual."); }

            if (soldVideoConsole.SalePrice < 0) { Errors.Add("El campo 'SalePrice' no puede ser negativo."); }

            if (soldVideoConsole.Name == null || soldVideoConsole.Name == "") { Errors.Add("El campo 'Name' no puede ser nulo ni estar vacío."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
