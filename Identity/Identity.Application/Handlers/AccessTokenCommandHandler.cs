using Identity.Application.Commands;
using Identity.Application.DTO;
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
    public class AccessTokenCommandHandler : IRequestHandler<AccessTokenCommand, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AccessTokenCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(AccessTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserByRefreshToken(command.RefreshToken);

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
