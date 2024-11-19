using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<string> GenerateCodeConfirmEmail(Guid userId);
        Task<bool> ConfirmEmail(Guid userId);
        Task<bool> ChangeIsDeletedUser(Guid userId, bool isDeleted);
        Task<bool> ChangePassword(Guid userId, string newHashPassword);
        Task<bool> IsVerifyCode(Guid userId, string code);
        Task<bool> UpdateUser(User user);
        Task<bool> SaveRefreshToken(Guid userId, string refreshToken, DateTime ExpirationDate);
        Task<User> GetUserByRefreshToken(string refreshToken);
    }
}
