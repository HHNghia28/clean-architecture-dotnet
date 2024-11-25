﻿using Identity.Application.Features.Auth.Commands.AccessToken;
using Identity.Application.Features.Auth.Commands.ChangeDeleteUser;
using Identity.Application.Features.Auth.Commands.ChangePassword;
using Identity.Application.Features.Auth.Commands.ConfirmEmail;
using Identity.Application.Features.Auth.Commands.ForgotPassword;
using Identity.Application.Features.Auth.Commands.LoginUser;
using Identity.Application.Features.Auth.Commands.RegisterUser;
using Identity.Application.Features.Auth.Commands.ResendEmail;
using Identity.Application.Features.Auth.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                if (response == null) return Unauthorized("Email or Password invalid");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("resend-confirm")]
        public async Task<IActionResult> ReSendConfirmEmail([FromBody] ResendConfirmEmailCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Resend successful");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Change password successful");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Email sended");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Reset password successful");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("access-token")]
        public async Task<IActionResult> AccessToken([FromBody] AccessTokenCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id}/block")]
        public async Task<IActionResult> Block(Guid id)
        {
            try
            {
                ChangeDeletedUserCommand command = new()
                {
                    IsDeleted = true,
                    UserId = id
                };

                await _mediator.Send(command);
                return Ok("Block successful");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id}/unblock")]
        public async Task<IActionResult> UnBlock(Guid id)
        {
            try
            {
                ChangeDeletedUserCommand command = new()
                {
                    IsDeleted = false,
                    UserId = id
                };

                await _mediator.Send(command);
                return Ok("UnBlock successful");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
