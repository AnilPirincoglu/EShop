using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string productDetailId { get; set; }
        public string productDescription { get; set; }
        public string productInformation { get; set; }
        public string productId { get; set; }

        [BsonIgnore]
        public Product product { get; set; }

    }
}
