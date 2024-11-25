using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ChangeDeleteUser
{
    public class ChangeDeletedUserCommandHandler : IRequestHandler<ChangeDeletedUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeDeletedUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ChangeDeletedUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.ChangeIsDeletedUser(request.UserId, request.IsDeleted);

            await _userRepository.SaveAsync();
        }
    }
}
