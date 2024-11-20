using Dapper;
using MediatR;
using Product.Application.DTO;
using Product.Application.Queries;
using Product.Domain.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetCategoriesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                const string categoriesQuery = @"
                    SELECT
                        ""Categories"".""Id"",
                        ""Categories"".""Name""
                    FROM ""Categories""
                    WHERE ""Categories"".""IsDeleted"" = false
                ";

                var categories = await connection.QueryAsync<CategoryResponse>(categoriesQuery);

                return categories.AsList();
            };
        }
    }
}
