using EShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(getOrderDetailByIdQuery.OrderDetailId);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                ProductAmount = orderDetail.ProductAmount,
                ProductPrice = orderDetail.ProductPrice,
                ProductName = orderDetail.ProductName,
                ProductTotalPrice = orderDetail.ProductTotalPrice
            };
            
        }
    }
}
