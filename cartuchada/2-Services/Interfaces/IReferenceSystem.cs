
using _1_Entities;
using _1_Entities.Interfaces;

namespace _2_Services.Interfaces
{
    public interface IReferenceSystem
    {
        Task AssignReferenceToProductAsync(IProduct product);
    }
}
