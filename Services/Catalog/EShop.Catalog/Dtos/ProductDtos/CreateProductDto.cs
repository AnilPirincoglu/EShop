namespace EShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public string productCategory { get; set; }
    }
}
