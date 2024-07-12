using EShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return orderDetails.Select(orderDetail => new GetOrderDetailQueryResult
            {
                OrderDetailId = orderDetail.OrderDetailId,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.ProductName,
                ProductPrice = orderDetail.ProductPrice,             
                ProductAmount = orderDetail.ProductAmount,
                ProductTotalPrice = orderDetail.ProductTotalPrice,
                OrderId = orderDetail.OrderId
            }).ToList();
        }
    }
}
