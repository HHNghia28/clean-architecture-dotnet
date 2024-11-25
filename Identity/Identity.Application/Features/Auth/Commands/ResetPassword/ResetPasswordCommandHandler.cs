using Identity.Application.Handlers;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ResetPasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var confirm = await _userRepository.IsVerifyCode(request.UserId, request.Code);

            if (confirm) await _userRepository.ChangePassword(request.UserId, _passwordHasher.HashPassword(request.Password));

            await _userRepository.SaveAsync();
        }
    }
}
