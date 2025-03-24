
namespace _1_Domain.Interfaces
{
    public interface IProduct
    {
        int IdProductType { get; }

        void AssignReference(int idReference, string reference);
    }
}
