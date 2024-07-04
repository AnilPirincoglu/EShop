using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string categoryId { get; set; }
        public string categoryName { get; set; }    
    }
}
