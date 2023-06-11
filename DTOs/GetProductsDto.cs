namespace OnlineShopAPI.DTOs
{
    public class GetProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
