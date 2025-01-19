﻿using MediatR;
using Order.Application.Exceptions;
using Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Order not found");

            if (order.Status != Domain.Enums.OrderStatus.PENDING) throw new InvalidOperationException("The order has expired and cannot be cancel");

            order.Status = Domain.Enums.OrderStatus.CANCEL;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }
    }
}
