using Identity.Application.Commands;
using Identity.Domain.Interfaces.Handlers;
using Identity.Domain.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.OldPassword, user.PasswordHash)) throw new Exception("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new Exception("Please confirm email");

            await _unitOfWork.Users.ChangePassword(user.Id, _passwordHasher.HashPassword(command.NewPassword));

            await _unitOfWork.SaveAsync();
        }
    }
}
