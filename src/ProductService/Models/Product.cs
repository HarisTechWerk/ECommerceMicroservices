namespace ProductService.Models
{
    public class Product
    {
        // EF Core will recognize 'Id' or 'ProductId' as the primary key by convention
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        // Example of a Stock Quantity (though we may handle stock in InventoryService,
        // it's fine to keep a "default" or "available" quantity for the product itself)
        public int StockQuantity { get; set; }
    }
}
