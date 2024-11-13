using Identity.Domain;
using Identity.Domain.Interfaces.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ConfirmEmail(Guid userId, string code)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            var confirm = await _context.EmailConfirmationTokens
                .FirstOrDefaultAsync(e => e.UserId == userId && e.Token.Equals(code) && e.ExpirationDate >= DateTime.UtcNow);

            if (confirm != null) user.IsEmailConfirmed = true;

            return confirm != null;
        }

        public async Task<string> GenerateCodeConfirmEmail(Guid userId)
        {
            string code = Util.Generate6DigitCode();

            await _context.EmailConfirmationTokens.AddAsync(new EmailConfirmationToken
            {
                Id = Guid.NewGuid(),
                ExpirationDate = DateTime.UtcNow.AddMinutes(5),
                Token = code,
                UserId = userId
            });

            return code;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
