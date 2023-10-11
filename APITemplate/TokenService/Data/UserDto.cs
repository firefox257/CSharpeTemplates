using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GlobalTypes;

namespace TokenService
{
    /// <summary>
    /// Model for the TokenService
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool Deleted { get; set; }
        public bool Blocked { get; set; }
        public bool EmailVerified { get; set; }
        public bool AdminVerified { get; set; }
        public string ? RoleId { get; set; }
    }
}