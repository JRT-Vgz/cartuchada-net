using _1_Entities.Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators
{
    public class ConsoleValidator : IProductValidator<VideoConsole>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public ConsoleValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(VideoConsole console)
        {
            var productTypeExists = await _context.ProductTypes.AnyAsync(p => p.Id == console.IdProductType);
            if (!productTypeExists) { Errors.Add($"No existe ningún tipo de producto con Id {console.IdProductType} en la tabla 'ProductType'."); }

            if (console.IdProductType != ValidationConstants._PRODUCT_TYPE_GAME_BOY_CONSOLE &&
                console.IdProductType != ValidationConstants._PRODUCT_TYPE_GAME_GEAR_CONSOLE)
            {
                Errors.Add($"El tipo de producto con Id {console.IdProductType} en la tabla 'ProductType' no corresponde con ninguna videoconsola.");
            }

            if (console.PurchaseDate != DateTime.Now.Date) { Errors.Add("El campo 'PurchaseDate' no coincide con la fecha actual."); }

            if (console.IdReference == 0 || console.Reference == null) { Errors.Add($"La consola que intentas comprar no tiene una referencia asignada."); }

            if (console.PurchasePrice < 0) { Errors.Add("El canpo 'PurchasePrice' no puede ser negativo."); }

            if (console.TotalPrice < 0) { Errors.Add("El campo 'TotalPrice' no puede ser negativo."); }

            if (console.Name == null || console.Name == "") { Errors.Add("El campo 'Name' no puede ser nulo ni estar vacío."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
