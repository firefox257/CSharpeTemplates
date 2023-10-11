﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingService
{
    public interface IPingService
    {
        public Task<PingResponse> GetHello();
        public Task<string> TestException();
    }
}