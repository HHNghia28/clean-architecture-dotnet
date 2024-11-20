﻿using Identity.Application.Commands;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Users.UpdateUser(new Domain.Models.User
            {
                Id = request.Id,
                Email = request.Email,
                FullName = request.FullName,
                RoleId = request.RoleId,
            });

            await _unitOfWork.SaveAsync();
        }
    }
}