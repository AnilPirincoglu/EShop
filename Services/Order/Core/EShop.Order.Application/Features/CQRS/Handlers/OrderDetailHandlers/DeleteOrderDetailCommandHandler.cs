using EShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(DeleteOrderDetailCommand deleteOrderDetailCommand)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(deleteOrderDetailCommand.OrderDetailId);
            await _orderDetailRepository.DeleteAsync(orderDetail);
        }
    }
}
