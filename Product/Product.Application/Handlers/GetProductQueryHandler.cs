using Dapper;
using MediatR;
using Product.Application.DTO;
using Product.Application.Queries;
using Product.Domain.Interfaces.Context;
using Product.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetProductQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            using (var connect = _connectionFactory.GetOpenConnection())
            {
                const string sqlProduct = @"
                    SELECT
                        ""Products"".""Id"",
                        ""Products"".""Name"",
                        ""Products"".""Description"",
                        ""Products"".""Price"",
                        ""Products"".""Discount"",
                        ""Products"".""Photo"",
                        ""Products"".""IsDeleted"",
                        ""Products"".""CreatedBy"",
                        ""Products"".""UpdatedBy"",
                        ""Products"".""CreatedAt"",
                        ""Products"".""UpdatedAt"",
                        ""Products"".""CategoryId"",
                        ""Categories"".""Name"" as ""Category""
                    FROM ""Products""
                    INNER JOIN ""Categories"" ON ""Products"".""CategoryId"" = ""Categories"".""Id""
                    WHERE ""Products"".""Id"" = @Id
                ";

                var product = await connect.QueryFirstOrDefaultAsync<ProductResponse>(sqlProduct, new { Id = request.Id });

                return product;
            }
        }
    }
}
