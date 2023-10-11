using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTypes;
namespace UserService
{
    public class AddUserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? First { get; set; }
        public string? Last { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public string ? Password { get; set; }
        public bool EmailVerified { get; set; }
        public bool AdminVerified { get; set; }
        public string? Email { get; set; }
        public string ? RoleId { get; set; }
    }
}
