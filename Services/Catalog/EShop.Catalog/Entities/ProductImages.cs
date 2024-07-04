using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EShop.Catalog.Entities
{
    public class ProductImages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string productImageId { get; set; }
        public string productImage1 { get; set; }
        public string productImage2 { get; set; }
        public string productImage3 { get; set; }
        public string productId { get; set; }

        [BsonIgnore]
        public Product product { get; set; }
    }
}
