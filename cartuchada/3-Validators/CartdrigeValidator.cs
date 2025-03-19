
using _1_Entities;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators
{
    public class CartdrigeValidator : IProductValidator<Cartdrige>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public CartdrigeValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(Cartdrige cartdrige)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == cartdrige.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {cartdrige.IdProductType} en la tabla 'ProductType'."); }

            if (cartdrige.IdProductType != ValidationConstants._PRODUCT_TYPE_GAME_BOY_CARTDRIGE &&
                cartdrige.IdProductType != ValidationConstants._PRODUCT_TYPE_GAME_GEAR_CARTDRIGE)
            {
                Errors.Add($"El tipo de producto con Id {cartdrige.IdProductType} en la tabla 'ProductType' no corresponde con ningún cartucho.");
            }

            var gameExists = await _context.Games.AnyAsync(g => g.Id == cartdrige.IdGame);
            if (!gameExists) { Errors.Add($"No existe ningún juego con Id {cartdrige.IdGame} en la tabla 'GameCatalogue'."); }

            var regionExists = await _context.Regions.AnyAsync(r => r.Id == cartdrige.IdRegion);
            if (!regionExists) { Errors.Add($"No existe ninguna región con Id {cartdrige.IdRegion} en la tabla 'Region'."); }

            var conditionExists = await _context.Conditions.AnyAsync(c => c.Id == cartdrige.IdCondition);
            if (!conditionExists) { Errors.Add($"No existe ninguna condición con Id {cartdrige.IdCondition} en la tabla 'Condition'."); }

            if (cartdrige.IdReference == 0 || cartdrige.Reference == null) { Errors.Add($"El cartucho que intentas comprar no tiene una referencia asignada."); }

            if (cartdrige.PurchaseDate != DateTime.Now.Date) { Errors.Add("El campo 'PurchaseDate' no coincide con la fecha actual."); }

            if (cartdrige.PurchasePrice < 0) { Errors.Add("El canpo 'PurchasePrice' no puede ser negativo."); }

            if (cartdrige.Name == null || cartdrige.Name == "") { Errors.Add("El campo 'Name' no puede ser nulo ni estar vacío."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
