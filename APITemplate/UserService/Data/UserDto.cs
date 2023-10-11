using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTypes;

namespace UserService
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? First { get; set; }
        public string? Last { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public bool Blocked { get; set; }
        public string ? BlockedReason { get; set; }
        public string? PassHash { get; set; }
        public bool EmailVerified { get; set; }
        public bool AdminVerified { get; set; }
        public string ? Email { get; set; }
        public string ? RoleId { get; set; }
    }
}
