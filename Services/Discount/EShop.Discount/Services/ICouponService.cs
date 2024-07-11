using EShop.Discount.Dtos;

namespace EShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
    }
}
