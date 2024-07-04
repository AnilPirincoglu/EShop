﻿namespace EShop.Catalog.Dtos.ProductDetailDtos
{
    public class GetByIdProductDetailDto
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public string productCategory { get; set; }
    }
}