using EShop.Catalog.Dtos.ProductImagesDtos;
using EShop.Catalog.Services.ProductImagesServices;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImagesService _productImageService;

        public ProductImagesController(IProductImagesService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var productImages = await _productImageService.GetAllProductImagesAsync();
            return Ok(productImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var productImage = await _productImageService.GetByIdProductImagesAsync(id);
            return Ok(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage([FromBody] CreateProductImagesDto createProductImageDto)
        {
            await _productImageService.CreateProductImagesAsync(createProductImageDto);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImagesAsync(id);
            return NoContent();
        }

        [HttpPut]   
        public async Task<IActionResult> UpdateProductImage([FromBody] UpdateProductImagesDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImagesAsync(updateProductImageDto);
            return Ok("Product Images Updated Successfully");
        }
    }
}
