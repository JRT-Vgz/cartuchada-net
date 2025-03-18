
namespace _1_Entities.Interfaces
{
    public interface IProduct
    {
        int IdProductType { get; }

        void AssignReference(int idReference, string reference);
    }
}
