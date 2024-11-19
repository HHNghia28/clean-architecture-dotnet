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
    public class ChangeIsDeletedUserCommandHandler : IRequestHandler<ChangeIsDeletedUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeIsDeletedUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangeIsDeletedUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Users.ChangeIsDeletedUser(request.UserId, request.IsDeleted);

            await _unitOfWork.SaveAsync();
        }
    }
}
