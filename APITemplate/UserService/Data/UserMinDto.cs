using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTypes;
namespace UserService
{
    public class UserMinDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public bool Deleted { get; set; }
        public bool EmailVerified { get; set; }
        public bool AdminVerified { get; set; }
        public string ? RoleId { get; set; }
    }
}
