﻿using Identity.Application.Features.Users.Commands.UpdateAccount;
using Identity.Application.Features.Users.Queries.GetUser;
using Identity.Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUsersQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserQuery
            {
                Id = id
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand request)
        {
            await _mediator.Send(request);
            return Ok("Update user successful");
        }
    }
}
