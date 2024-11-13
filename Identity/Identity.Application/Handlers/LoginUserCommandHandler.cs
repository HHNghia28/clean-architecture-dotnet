using Identity.Application.Commands;
using Identity.Application.DTO;
using Identity.Domain.Interfaces.Handlers;
using Identity.Domain.Interfaces.Services;
using Identity.Domain.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(command.Email);
            if (user == null || !_passwordHasher.VerifyPassword(command.Password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials");
            }

            var token = _tokenService.GenerateJwtToken(user);

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = token
            };
        }
    }
}
