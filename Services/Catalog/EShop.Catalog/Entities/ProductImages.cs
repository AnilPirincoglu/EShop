namespace EShop.Catalog.Entities
{
    public class ProductImages
    {
        public string productImageId { get; set; }
        public string productImage1 { get; set; }
        public string productImage2 { get; set; }
        public string productImage3 { get; set; }
        public string productId { get; set; }
        public Product product { get; set; }
    }
}
