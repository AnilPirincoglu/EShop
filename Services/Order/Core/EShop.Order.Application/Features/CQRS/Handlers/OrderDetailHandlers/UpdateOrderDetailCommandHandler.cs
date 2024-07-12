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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            orderDetail.ProductId = updateOrderDetailCommand.ProductId;
            orderDetail.ProductName = updateOrderDetailCommand.ProductName;
            orderDetail.ProductPrice = updateOrderDetailCommand.ProductPrice;
            orderDetail.ProductAmount = updateOrderDetailCommand.ProductAmount;
            orderDetail.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            orderDetail.OrderId = updateOrderDetailCommand.OrderId;
            await _orderDetailRepository.UpdateAsync(orderDetail);
        }
    }
}
