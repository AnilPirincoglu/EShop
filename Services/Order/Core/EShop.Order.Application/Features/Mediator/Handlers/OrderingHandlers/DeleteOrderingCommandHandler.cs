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
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderingRepository.GetByIdAsync(request.OrderId);
            await _orderingRepository.DeleteAsync(order);
        }
    }
}
