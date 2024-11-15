using Identity.Application.Commands;
using Identity.Domain.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmEmailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<bool> IRequestHandler<ConfirmEmailCommand, bool>.Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirm = await _unitOfWork.Users.IsVerifyCode(request.UserId, request.Code);

            if (confirm) await _unitOfWork.Users.ConfirmEmail(request.UserId);

            await _unitOfWork.SaveAsync();

            return confirm;
        }
    }
}
