using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Interfaces.Services
{
    public interface IAuthenticatedUserService
    {
        public string UserId { get; }
        public string Name { get; }
        public string Email { get; }
        public string Role { get; }
    }
}
