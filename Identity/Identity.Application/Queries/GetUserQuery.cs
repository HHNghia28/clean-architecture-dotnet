using Identity.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
