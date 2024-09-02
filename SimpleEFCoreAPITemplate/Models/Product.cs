namespace SimpleEFCoreAPITemplate.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BasePrice { get; set; } = 11.99m;
        public string ImageUrl { get; set; } = "Blob/Products/emptyImage.jpg";
    }
}
 