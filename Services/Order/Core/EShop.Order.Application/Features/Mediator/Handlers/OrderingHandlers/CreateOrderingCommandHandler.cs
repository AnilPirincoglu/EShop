using EShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _orderRepository;

        public CreateOrderingCommandHandler(IRepository<Ordering> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                OrderTotalPrice = request.OrderTotalPrice,
                UserId = request.UserId
            });
        }
    }
}
