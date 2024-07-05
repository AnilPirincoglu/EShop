using AutoMapper;
using EShop.Catalog.Dtos.ProductDtos;
using EShop.Catalog.Entities;
using EShop.Catalog.Settings;
using MongoDB.Driver;

namespace EShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.connectionString);
            var database = client.GetDatabase(_databaseSettings.databaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.productCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.productId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var product = await _productCollection.Find(x => x.productId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.ReplaceOneAsync(x => x.productId == updateProductDto.productId, product);
        }
    }
}
