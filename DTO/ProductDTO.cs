namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } 
        public string CategoryName { get; set; }
    }
}