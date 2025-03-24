using _1_Domain.Interfaces;

namespace _2_Services.Interfaces
{
    public interface IReferenceSystem
    {
        Task AssignReferenceToProductAsync(IProduct product);
        Task ReleaseReferenceByIdAsync(int idReference);
    }
}
