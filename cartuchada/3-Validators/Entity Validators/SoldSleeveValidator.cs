
using _1_Domain.Constants;
using _1_Domain.Sold_Product_Entities;
using _2_Services.Interfaces;
using _3_Data;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Entity_Validators 
{
    public class SoldSleeveValidator : IProductValidator<SoldSleeve>
    {
        public List<string> Errors { get; set; }
        private readonly AppDbContext _context;

        public SoldSleeveValidator(AppDbContext context)
        {
            Errors = new List<string>();
            _context = context;
        }

        public async Task<bool> ValidateProductAsync(SoldSleeve soldSleeve)
        {
            var sparePartTypeExists = await _context.SparePartTypes.AnyAsync(p => p.Id == soldSleeve.IdSparePartType);
            if (!sparePartTypeExists) { Errors.Add($"No existe ning�n recambio con Id {soldSleeve.IdSparePartType} en la tabla 'SparePartType'."); }

            if (soldSleeve.IdSparePartType != SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_BOY_SLEEVE &&
                soldSleeve.IdSparePartType != SparePartTypeConstants._SPARE_PART_TYPE_FAKE_GAME_GEAR_SLEEVE &&
                soldSleeve.IdSparePartType != SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_BOY_SLEEVE &&
                soldSleeve.IdSparePartType != SparePartTypeConstants._SPARE_PART_TYPE_ORIGINAL_GAME_GEAR_SLEEVE)
            {
                Errors.Add($"El tipo de recambio con Id {soldSleeve.IdSparePartType} en la tabla 'SparePartType' no corresponde con ninguna funda.");
            }

            if (Errors.Count > 0) { return false; }
            return true;
        }
    }
}
