namespace ProductService.Models
{
    public class Product
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int StockQuantity { get; set; }
    }
}