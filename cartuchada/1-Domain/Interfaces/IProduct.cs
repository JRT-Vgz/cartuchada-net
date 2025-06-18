
namespace _1_Domain.Interfaces
{
    public interface IProduct
    {
        int IdReference { get; }
        int IdProductType { get; }
        DateTime PurchaseDate { get; }
        decimal PurchasePrice { get; }
        string? Name { get; }
        string? Reference { get; }

        void AssignReference(int idReference, string reference);
    }
}
