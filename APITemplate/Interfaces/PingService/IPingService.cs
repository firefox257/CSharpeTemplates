using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.PingService
{
    public interface IPingService
    {
        public Task<PingResponse> GetHello();
    }
}
