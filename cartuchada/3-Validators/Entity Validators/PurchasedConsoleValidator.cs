using _1_Domain.Product_Entities;
using _1_Domain.Constants;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Entity_Validators
{
    public class PurchasedConsoleValidator : IProductValidator<VideoConsole>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public PurchasedConsoleValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(VideoConsole console)
        {
            if (console.IdReference == 0 || console.Reference == null) { Errors.Add($"La consola que intentas comprar no tiene una referencia asignada."); }

            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == console.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {console.IdProductType} en la tabla 'ProductType'."); }

            if (console.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE &&
                console.IdProductType != ProductTypeConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE)
            {
                Errors.Add($"El tipo de producto con Id {console.IdProductType} en la tabla 'ProductType' no corresponde con ninguna videoconsola.");
            }

            if (console.PurchaseDate == default) { Errors.Add("No se ha asignado correctamente la fecha de compra."); }

            if (console.PurchasePrice <= 0) { Errors.Add("El precio del cartucho debe ser mayor a 0."); }

            if (console.SparePartsPrice < 0) { Errors.Add("El campo 'SparePartsPrice' no puede ser negativo."); }

            if (console.TotalPrice <= 0) { Errors.Add("El campo 'TotalPrice' debe ser mayor a 0."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
