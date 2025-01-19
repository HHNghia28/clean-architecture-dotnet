﻿using Dapper;
using Order.Application.DTO;
using Order.Application.Interfaces;
using Order.Application.Wrappers;
using Order.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory) : Repository<Domain.Entities.Order>(context), IOrderRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

        public Task<OrderResponse> GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrders(PagedRequest request)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlOrders = @"
                    SELECT 
                        ""Orders"".""Id"",
                        ""Orders"".""FullName"",
                        ""Orders"".""Phone"",
                        ""Orders"".""Address"",
                        ""Orders"".""TotalPrice"",
                        ""Orders"".""Status"",
                        ""Orders"".""CreatedAt"",
                        ""Orders"".""LastModifiedAt""
                    FROM ""Orders""
                    ORDER BY ""Orders"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var Orders = await connection.QueryAsync<OrdersResponse>(sqlOrders, new { Offset = offset, PageSize = request.PageSize });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Orders""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<OrdersResponse>>(
                Orders.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }

        public async Task<PagedResponse<List<OrdersResponse>>> GetOrdersByUserId(PagedRequest request, Guid userId)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlOrders = @"
                    SELECT 
                        ""Orders"".""Id"",
                        ""Orders"".""FullName"",
                        ""Orders"".""Phone"",
                        ""Orders"".""Address"",
                        ""Orders"".""TotalPrice"",
                        ""Orders"".""Status"",
                        ""Orders"".""CreatedAt"",
                        ""Orders"".""LastModifiedAt""
                    FROM ""Orders""
                    WHERE ""Orders"".""CreatedBy"" = @Id
                    ORDER BY ""Orders"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var Orders = await connection.QueryAsync<OrdersResponse>(sqlOrders, new { Offset = offset, PageSize = request.PageSize, Id = userId });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Orders""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<OrdersResponse>>(
                Orders.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }
    }
}
