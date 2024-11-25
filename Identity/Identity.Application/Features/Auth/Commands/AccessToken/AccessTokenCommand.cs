﻿using Identity.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.AccessToken
{
    public class AccessTokenCommand : IRequest<LoginResponse>
    {
        public string RefreshToken { get; set; }
    }
}