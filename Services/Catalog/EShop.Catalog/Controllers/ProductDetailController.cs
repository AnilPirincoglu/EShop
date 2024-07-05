using EShop.Catalog.Dtos.ProductDetailDtos;
using EShop.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            this._productDetailService = productDetailService;
        }
        
        [HttpGet]
            public async Task<IActionResult> GetAllProductDetails()
            {
                var productDetails = await _productDetailService.GetAllProductDetailAsync();
                return Ok(productDetails);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetProductDetailById(string id)
            {
                var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
                return Ok(productDetail);
            }

            [HttpPost]
            public async Task<IActionResult> CreateProductDetail([FromBody] CreateProductDetailDto createProductDetailDto)
            {
                await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
                return Created();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProductDetail(string id)
            {
                await _productDetailService.DeleteProductDetailAsync(id);
                return NoContent();
            }

            [HttpPut]
            public async Task<IActionResult> UpdateProductDetail([FromBody] UpdateProductDetailDto updateProductDetailDto)
            {
                await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
                return Ok("Product Detail Updated Successfully");
            }
        }
    }

