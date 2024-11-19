﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Commands
{
    public class ChangeIsDeletedUserCommand : IRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
