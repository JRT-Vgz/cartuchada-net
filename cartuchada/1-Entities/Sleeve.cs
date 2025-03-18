
namespace _1_Entities
{
    public class Sleeve
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Sleeve(int id, int quantity, string name)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
