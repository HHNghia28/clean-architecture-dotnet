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
    public class ResendConfirmEmailCommandHandler : IRequestHandler<ResendConfirmEmailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public ResendConfirmEmailCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IEmailSender emailSender, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        async Task IRequestHandler<ResendConfirmEmailCommand>.Handle(ResendConfirmEmailCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(command.Email);

            if (existingUser == null) throw new Exception("User not found");

            string code = await _unitOfWork.Users.GenerateCodeConfirmEmail(existingUser.Id);

            await _unitOfWork.SaveAsync();

            string url = _configuration["Base:Url"] ?? string.Empty;
            string content = url + "/api/auth/confirm-email?userId=" + existingUser.Id + "&code=" + code;

            await _emailSender.SendEmailAsync(existingUser.Email, "Confirm email", content);
        }
    }
}
