using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Catalog.Entities
{
    public class ProductDetail
    {
        public string productDetailId { get; set; }
        public string productDescription { get; set; }
        public string productInformation { get; set; }

    }
}
