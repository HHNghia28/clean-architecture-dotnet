using Dapper;
using Identity.Application.DTO;
using Identity.Application.Queries;
using Identity.Application.Wrappers;
using Identity.Domain.Interfaces.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, PagedResponse<List<UserListResponse>>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetListUserQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PagedResponse<List<UserListResponse>>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                const string sqlUsers = @"
                    SELECT 
                        ""Users"".""Id"",
                        ""Users"".""FullName"",
                        ""Users"".""Email"",
                        ""Roles"".""Name"" AS ""Role""
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""
                    WHERE ""Users"".""IsDeleted"" = false
                    ORDER BY ""Users"".""FullName""
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var offset = (request.PageNumber - 1) * request.PageSize;
                var users = await connection.QueryAsync<UserListResponse>(sqlUsers, new { Offset = offset, PageSize = request.PageSize });

                const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""";

                var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

                var response = new PagedResponse<List<UserListResponse>>(
                    users.AsList(),
                    request.PageNumber,
                    request.PageSize,
                    (int)Math.Ceiling((double)totalRecords / request.PageSize)
                );

                return response;
            }
        }
    }
}
