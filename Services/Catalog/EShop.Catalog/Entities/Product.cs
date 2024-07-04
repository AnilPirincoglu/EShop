using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string productId { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public string productCategory { get; set; }

        [BsonIgnore]
        public Category category { get; set; }
    }
}
