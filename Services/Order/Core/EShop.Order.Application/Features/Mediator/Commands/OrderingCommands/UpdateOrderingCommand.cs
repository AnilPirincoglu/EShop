using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class UpdateOrderingCommand :IRequest
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
