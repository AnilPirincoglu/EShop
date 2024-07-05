using EShop.Catalog.Dtos.ProductImagesDtos;

namespace EShop.Catalog.Services.ProductImagesServices
{
    public interface IProductImagesService
    {
        Task CreateProductImagesAsync(CreateProductImagesDto createProductImageDto);
        Task DeleteProductImagesAsync(string id);
        Task<List<ResultProductImagesDto>> GetAllProductImagesAsync();
        Task<GetByIdProductImagesDto> GetByIdProductImagesAsync(string id);
        Task UpdateProductImagesAsync(UpdateProductImagesDto updateProductImageDto);
    }
}
