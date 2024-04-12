namespace SampleDevops.Models
{
    public class ProductEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public string Design { get; set; }
    }
}
