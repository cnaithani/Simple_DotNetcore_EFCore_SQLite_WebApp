namespace SimpleEFCoreAPITemplate.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;
        public string Dimentions { get; set; } = string.Empty;
    }
}
