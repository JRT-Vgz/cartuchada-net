
using _1_Domain.Constants;
using _1_Domain.Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Entity_Validators
{
    public class SpotedCartdrigeValidator : INonReferencedProductValidator<Cartdrige>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public SpotedCartdrigeValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(Cartdrige cartdrige)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == cartdrige.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ning�n tipo de producto con Id {cartdrige.IdProductType} en la tabla 'ProductType'."); }

            if (cartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CARTDRIGE &&
                cartdrige.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CARTDRIGE)
            {
                Errors.Add($"El tipo de producto con Id {cartdrige.IdProductType} en la tabla 'ProductType' no corresponde con ning�n cartucho.");
            }

            var gameExists = await _context.Games.AnyAsync(g => g.Id == cartdrige.IdGame);
            if (!gameExists) { Errors.Add($"No existe ning�n juego con Id {cartdrige.IdGame} en la tabla 'GameCatalogue'."); }

            var regionExists = await _context.Regions.AnyAsync(r => r.Id == cartdrige.IdRegion);
            if (!regionExists) { Errors.Add($"No existe ninguna regi�n con Id {cartdrige.IdRegion} en la tabla 'Region'."); }

            var conditionExists = await _context.Conditions.AnyAsync(c => c.Id == cartdrige.IdCondition);
            if (!conditionExists) { Errors.Add($"No existe ninguna condici�n con Id {cartdrige.IdCondition} en la tabla 'Condition'."); }

            if (cartdrige.PurchaseDate == default) { Errors.Add("No se ha asignado correctamente la fecha de spot."); }

            if (cartdrige.PurchasePrice <= 0) { Errors.Add("El precio del cartucho debe ser mayor a 0."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
