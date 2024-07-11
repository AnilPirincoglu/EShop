using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Domain.Entities
{
    internal class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Adress Adress { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
