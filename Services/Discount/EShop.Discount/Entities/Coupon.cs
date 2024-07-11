namespace EShop.Discount.Entities
{
    public class Coupon
    {
        public int couponId { get; set; }
        public string code { get; set; }
        public int rate { get; set; }
        public bool isActive { get; set; }
        public DateTime validDate { get; set; }
    }
}
