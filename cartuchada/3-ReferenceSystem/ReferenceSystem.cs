using _1_Domain.Interfaces;
using _2_Services.Exceptions;
using _2_Services.Interfaces;
using _3_Data;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_ReferenceSystem
{
    public class ReferenceSystem : IReferenceSystem
    {
        private readonly AppDbContext _context;
        public ReferenceSystem(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignReferenceToProductAsync(IProduct product)
        {
            // Busca una referencia que no esté asignada.
            var referenceModel = await _context.References
                .Where(r => r.IdProductType == product.IdProductType && r.Assigned == false)
                .FirstOrDefaultAsync();

            // Si todas las referencias están asignadas, crea una nueva referencia para ese tipo de producto.
            if (referenceModel == null) 
            {
                try
                {
                    referenceModel = await CreateNewReferenceAsync(product.IdProductType);
                    await _context.References.AddAsync(referenceModel);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw new ReferenceSystemException("Error al crear una referencia nueva en el sistema de referencias. ");
                }
            }

            // Marca la referencia como asignada, updatea y asignala al producto.
            referenceModel.Assigned = true;

            try { _context.References.Update(referenceModel); }
            catch (Exception) { throw new ReferenceSystemException("Error al actualizar la referencia en la tabla 'Reference'."); }

            product.AssignReference(referenceModel.Id, referenceModel.Name);
        }

        public async Task ReleaseReferenceByIdAsync(int idReference)
        {
            var referenceModel = await _context.References.FirstOrDefaultAsync(r => r.Id == idReference);

            if (referenceModel == null)
            {
                throw new ReferenceSystemException($"No se ha encontrado la referencia {idReference} en la tabla 'Reference'. ");
            }

            if (referenceModel.Assigned == false)
            {
                throw new ReferenceSystemException($"No se puede liberar la referencia {idReference} de la tabla 'Reference' porque " +
                    $"no está asignada a ningún producto. ");
            }

            referenceModel.Assigned = false;

            try { _context.References.Update(referenceModel); }
            catch (Exception) { throw new ReferenceSystemException("Error al actualizar la referencia en la tabla 'Reference'."); }
        }

        private async Task<ReferenceModel> CreateNewReferenceAsync(int idProductType) 
        {
            // Cuenta las referencias actuales para el producto.
            int actualReferenceCount = await _context.References
                .Where(r => r.IdProductType == idProductType)
                .CountAsync();

            // Obtén el tipo de producto para acceder al prefijo de referencia.
            ProductTypeModel productTypeModel = await _context.ProductTypes
                .Where(p => p.Id == idProductType)
                .FirstOrDefaultAsync();

            if (productTypeModel == null) { throw new Exception(); }

            // Crea el nombre de la nueva referencia.
            string newReferenceName = $"{productTypeModel.ReferencePrefix}{actualReferenceCount + 1}";

            // Crea la referencia y devuelvela.
            return new ReferenceModel() { IdProductType = idProductType, Name = newReferenceName, Assigned = false };
        }
    }
}
