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
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public ResetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var confirm = await _unitOfWork.Users.IsVerifyCode(request.UserId, request.Code);

            if (confirm) await _unitOfWork.Users.ChangePassword(request.UserId, _passwordHasher.HashPassword(request.Password));

            await _unitOfWork.SaveAsync();
        }
    }
}
