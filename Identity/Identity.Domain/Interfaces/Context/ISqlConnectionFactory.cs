﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Context
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}