using Identity.Application.Commands;
using Identity.Domain.Interfaces.Handlers;
using Identity.Domain.Interfaces.UnitOfWork;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IEmailSender emailSender, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        async Task IRequestHandler<RegisterUserCommand>.Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(command.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            Guid userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                FullName = command.FullName,
                Email = command.Email,
                PasswordHash = _passwordHasher.HashPassword(command.Password),
                RoleId = command.RoleId
            };

            await _unitOfWork.Users.AddAsync(user);

            string code = await _unitOfWork.Users.GenerateCodeConfirmEmail(userId);

            await _unitOfWork.SaveAsync();

            string url = _configuration["Base:Url"] ?? string.Empty;
            string content = url + "/api/confirm-email?userId=" + userId + "&code=" + code;

            await _emailSender.SendEmailAsync(command.Email, "Confirm email", content);
        }
    }
}
