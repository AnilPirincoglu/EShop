using AutoMapper;
using EShop.Catalog.Dtos.CategoryDtos;
using EShop.Catalog.Dtos.ProductDetailDtos;
using EShop.Catalog.Dtos.ProductDtos;
using EShop.Catalog.Dtos.ProductImagesDtos;
using EShop.Catalog.Entities;

namespace EShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImages,ResultProductImagesDto>().ReverseMap();
            CreateMap<ProductImages,CreateProductImagesDto>().ReverseMap();
            CreateMap<ProductImages,UpdateProductImagesDto>().ReverseMap();
            CreateMap<ProductImages,GetByIdProductImagesDto>().ReverseMap();
        }
    }
}
