﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Shares
{
    public static class Util
    {
        private static readonly Random random = new Random();

        public static string Generate6DigitCode()
        {
            int code = random.Next(100000, 1000000);
            return code.ToString();
        }
    }
}