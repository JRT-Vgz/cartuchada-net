using _1_Domain.Purchase_Entities;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Entity_Validators
{
    public class SparePartsPurchaseValidator : IProductValidator<SparePartsPurchase>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public SparePartsPurchaseValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(SparePartsPurchase sparePartsPurchase)
        {
            var sparePartTypeExists = await _context.SparePartTypes.AnyAsync(s => s.Id == sparePartsPurchase.IdSparePartType);
            if (!sparePartTypeExists) { Errors.Add($"No existe ningún tipo de recambio con Id {sparePartsPurchase.IdSparePartType} en la tabla 'SparePartType'."); }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
