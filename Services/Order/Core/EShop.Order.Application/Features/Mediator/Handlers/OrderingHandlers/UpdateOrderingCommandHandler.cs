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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);
            order.OrderDate = request.OrderDate;
            order.OrderTotalPrice = request.OrderTotalPrice;
            order.UserId = request.UserId;
            await _repository.UpdateAsync(order);
        }
    }
}
