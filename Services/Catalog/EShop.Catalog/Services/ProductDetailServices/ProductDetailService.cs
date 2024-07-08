﻿using AutoMapper;
using EShop.Catalog.Dtos.ProductDetailDtos;
using EShop.Catalog.Entities;
using EShop.Catalog.Settings;
using MongoDB.Driver;

namespace EShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.connectionString);
            var database = client.GetDatabase(_databaseSettings.databaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.productDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.productId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var productDetails =await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find(x => x.productId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.ReplaceOneAsync(x => x.productId == updateProductDetailDto.productId, productDetail);
        }
    }
}