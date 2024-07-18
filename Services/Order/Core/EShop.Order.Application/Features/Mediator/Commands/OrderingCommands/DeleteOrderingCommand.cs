using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class DeleteOrderingCommand :IRequest
    {
        public int OrderId { get; set; }

        public DeleteOrderingCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
