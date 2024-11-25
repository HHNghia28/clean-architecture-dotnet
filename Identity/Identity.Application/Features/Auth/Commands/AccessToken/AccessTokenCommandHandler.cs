﻿using Identity.Application.DTO;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.AccessToken
{
    public class AccessTokenCommandHandler : IRequestHandler<AccessTokenCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccessTokenCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(AccessTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByRefreshToken(command.RefreshToken);

            if (user == null) throw new Exception("Invalid refresh token");

            var accessToken = _tokenService.GenerateJwtToken(user);

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = command.RefreshToken
            };
        }
    }
}