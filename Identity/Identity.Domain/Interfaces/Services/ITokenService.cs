﻿using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}
