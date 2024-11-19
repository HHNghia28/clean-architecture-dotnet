using Dapper;
using Identity.Application.DTO;
using Identity.Application.Queries;
using Identity.Domain.Interfaces.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetUserQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _connectionFactory.GetOpenConnection())
            {
                const string sqlUsers = @"
                    SELECT 
                        ""Users"".""Id"",
                        ""Users"".""FullName"",
                        ""Users"".""Email"",
                        ""Users"".""IsEmailConfirmed"",
                        ""Users"".""IsDeleted"",
                        ""Users"".""RoleId"",
                        ""Roles"".""Name"" AS ""Role""
                    FROM ""Users""
                    INNER JOIN ""Roles"" ON ""Users"".""RoleId"" = ""Roles"".""Id""
                    WHERE ""Users"".""Id"" = @Id";

                var user = await connection.QueryFirstOrDefaultAsync<UserResponse>(sqlUsers, new {Id = request.Id});

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                return user;
            }
        }
    }
}
