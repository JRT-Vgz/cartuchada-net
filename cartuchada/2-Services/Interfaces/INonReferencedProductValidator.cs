
using _1_Domain.Interfaces;

namespace _2_Services.Interfaces
{
    public interface INonReferencedProductValidator<TCartdrige>
    {
        public List<string> Errors { get; set; }
        Task<bool> ValidateProductAsync(TCartdrige cartdrige);
    }
}
