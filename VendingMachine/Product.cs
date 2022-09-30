using LiteDB;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class Product
    {
        [BsonId]
        public int ColumnID { get; set; }

        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
