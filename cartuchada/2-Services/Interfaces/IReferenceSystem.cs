using _1_Entities.Interfaces;

namespace _2_Services.Interfaces
{
    public interface IReferenceSystem
    {
        Task AssignReferenceToProductAsync(IProduct product);
        Task ReleaseReferenceByIdAsync(int idReference);
    }
}
