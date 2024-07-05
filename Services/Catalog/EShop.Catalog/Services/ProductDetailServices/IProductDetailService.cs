using EShop.Catalog.Dtos.ProductDetailDtos;

namespace EShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task DeleteProductDetailAsync(string id);
    }
}
