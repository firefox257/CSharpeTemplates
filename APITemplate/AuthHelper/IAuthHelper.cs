using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHelper
{
    public interface IAuthHelper
    {
        public Task<string> SaltHashPass(string ? password);
    }
}
