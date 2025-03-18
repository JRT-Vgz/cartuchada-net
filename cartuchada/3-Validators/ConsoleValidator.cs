
using _1_Entities;
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

            var systemExists = await _context.Systems.AnyAsync(s => s.Id == console.IdSystem);
            if (!systemExists) { Errors.Add($"No existe ningún sistema con Id {console.IdSystem} en la tabla 'System'."); }

            if (console.IdReference == 0 || console.Reference == null) { Errors.Add($"La consola que intentas comprar no tiene una referencia asignada."); }

            if (console.PurchasePrice < 0) { Errors.Add("No se puede comprar una consola con precio negativo."); }

            if (console.TotalPrice < 0) { Errors.Add("No se puede comprar una consola con precio total negativo."); }

            if (console.Name == null) { Errors.Add("El campo 'Name' no puede ser nulo."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
