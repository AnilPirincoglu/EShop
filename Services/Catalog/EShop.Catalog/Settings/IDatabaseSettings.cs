namespace EShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string categoryCollectionName { get; set; }
        public string productCollectionName { get; set; }
        public string productDetailCollectionName { get; set; }
        public string productImageCollectionName { get; set; }
        public string connectionString { get; set; }
        public string databaseName { get; set; }
    }
}
