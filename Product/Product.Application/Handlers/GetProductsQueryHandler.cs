using Dapper;
using MediatR;
using Product.Application.DTO;
using Product.Application.Queries;
using Product.Application.Wrappers;
using Product.Domain.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResponse<List<ProductsResponse>>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetProductsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PagedResponse<List<ProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                const string sqlProducts = @"
                    SELECT 
                        ""Products"".""Id"",
                        ""Products"".""Name"",
                        ""Products"".""Price"",
                        ""Products"".""Discount"",
                        ""Products"".""Photo"",
                        ""Products"".""UpdatedAt"",
                        ""Products"".""CategoryId"",
                        ""Categories"".""Name"" AS ""Category""
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""
                    WHERE ""Products"".""IsDeleted"" = false
                    ORDER BY ""Products"".""UpdatedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var offset = (request.PageNumber - 1) * request.PageSize;
                var products = await connection.QueryAsync<ProductsResponse>(sqlProducts, new { Offset = offset, PageSize = request.PageSize });

                const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""";

                var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

                var response = new PagedResponse<List<ProductsResponse>>(
                    products.AsList(),
                    request.PageNumber,
                    request.PageSize,
                    (int)Math.Ceiling((double)totalRecords / request.PageSize)
                );

                return response;
            }
        }
    }
}
