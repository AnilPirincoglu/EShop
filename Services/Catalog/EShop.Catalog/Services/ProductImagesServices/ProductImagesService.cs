using AutoMapper;
using EShop.Catalog.Dtos.ProductImagesDtos;
using EShop.Catalog.Entities;
using EShop.Catalog.Settings;
using MongoDB.Driver;

namespace EShop.Catalog.Services.ProductImagesServices
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly IMongoCollection<ProductImages> _productImagesCollection;
        private readonly IMapper _mapper;

        public ProductImagesService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.productImageCollectionName);
            var database = client.GetDatabase(_databaseSettings.databaseName);
            _productImagesCollection = database.GetCollection<ProductImages>(_databaseSettings.productImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImagesAsync(CreateProductImagesDto createProductImageDto)
        {
            var productImage = _mapper.Map<ProductImages>(createProductImageDto);
            await _productImagesCollection.InsertOneAsync(productImage);
        }

        public async Task DeleteProductImagesAsync(string id)
        {
            await _productImagesCollection.DeleteOneAsync(x => x.productImageId == id);
        }

        public async Task<List<ResultProductImagesDto>> GetAllProductImagesAsync()
        {
            var productImages =await _productImagesCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImagesDto>>(productImages);
        }

        public async Task<GetByIdProductImagesDto> GetByIdProductImagesAsync(string id)
        {
            var productImage =await _productImagesCollection.Find(x => x.productImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImagesDto>(productImage);
        }

        public async Task UpdateProductImagesAsync(UpdateProductImagesDto updateProductImageDto)
        {
            var productImage = _mapper.Map<ProductImages>(updateProductImageDto);
            await _productImagesCollection.ReplaceOneAsync(x => x.productImageId == updateProductImageDto.productImageId, productImage);
        }
    }
}
