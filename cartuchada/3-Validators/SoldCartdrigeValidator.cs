
using _1_Entities.Sold_Product_Entities;
using _1_Entities.Constants;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators
{
    public class SoldCartdrigeValidator : IProductValidator<SoldCartdrige>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public SoldCartdrigeValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(SoldCartdrige soldCartdrige)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == soldCartdrige.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {soldCartdrige.IdProductType} en la tabla 'ProductType'."); }

            if (soldCartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CARTDRIGE &&
                soldCartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CARTDRIGE)
            {
                Errors.Add($"El tipo de producto con Id {soldCartdrige.IdProductType} en la tabla 'ProductType' no corresponde con ningún cartucho.");
            }

            var gameExists = await _context.Games.AnyAsync(g => g.Id == soldCartdrige.IdGame);
            if (!gameExists) { Errors.Add($"No existe ningún juego con Id {soldCartdrige.IdGame} en la tabla 'GameCatalogue'."); }

            var regionExists = await _context.Regions.AnyAsync(r => r.Id == soldCartdrige.IdRegion);
            if (!regionExists) { Errors.Add($"No existe ninguna región con Id {soldCartdrige.IdRegion} en la tabla 'Region'."); }

            var conditionExists = await _context.Conditions.AnyAsync(c => c.Id == soldCartdrige.IdCondition);
            if (!conditionExists) { Errors.Add($"No existe ninguna condición con Id {soldCartdrige.IdCondition} en la tabla 'Condition'."); }

            var cartdrigeExists = await _context.Cartdriges.AnyAsync(c => c.Id == soldCartdrige.IdCartdrige);
            if (!conditionExists) { Errors.Add($"No existe ningun cartucho con Id {soldCartdrige.IdCartdrige} en la tabla 'Cartdrige'."); }

            if (soldCartdrige.PurchasePrice < 0) { Errors.Add("El campo 'PurchasePrice' no puede ser negativo."); }

            if (soldCartdrige.SaleDate != DateTime.Now.Date) { Errors.Add("El campo 'SaleDate' no coincide con la fecha actual."); }

            if (soldCartdrige.SalePrice < 0) { Errors.Add("El campo 'SalePrice' no puede ser negativo."); }

            if (soldCartdrige.Name == null || soldCartdrige.Name == "") { Errors.Add("El campo 'Name' no puede ser nulo ni estar vacío."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
