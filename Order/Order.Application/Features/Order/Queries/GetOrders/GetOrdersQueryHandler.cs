﻿using MediatR;
using Order.Application.DTO;
using Order.Application.Interfaces;
using Order.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Queries.GetOrders
{
    public class GetOrdersQueryHandler(IOrderRepository OrderRepository) : IRequestHandler<GetOrdersQuery, PagedResponse<List<OrdersResponse>>>
    {
        private readonly IOrderRepository _orderRepository = OrderRepository;

        public async Task<PagedResponse<List<OrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrders(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}
