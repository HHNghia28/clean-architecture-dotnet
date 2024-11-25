using Identity.Application.DTO;
using Identity.Application.Handlers;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.Password, user.PasswordHash)) throw new Exception("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new Exception("Please confirm email");

            var accessToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(64);

            await _userRepository.SaveRefreshToken(user.Id, refreshToken, DateTime.UtcNow.AddDays(1));
            await _userRepository.SaveAsync();

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
