using _1_Domain.Product_Entities;
using _1_Domain.Constants;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;
using _1_Domain.Sold_Product_Entities;

namespace _3_Validators.Entity_Validators
{
    public class PurchasedCartdrigeValidator : IProductValidator<Cartdrige>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public PurchasedCartdrigeValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(Cartdrige cartdrige)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == cartdrige.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {cartdrige.IdProductType} en la tabla 'ProductType'."); }

            if (cartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CARTDRIGE &&
                cartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CARTDRIGE)
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

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
