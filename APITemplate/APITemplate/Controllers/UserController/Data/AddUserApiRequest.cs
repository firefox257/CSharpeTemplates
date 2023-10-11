using UserService;

namespace APITemplate.Controllers.UserController
{
    /// <summary>
    /// The class is a model for what the end point
    /// </summary>
    public class AddUserApiRequest
    {
        public string ? UserName { get; set; }
        public string ? First { get; set; }
        public string ? Last { get; set; }
        public string ? Email { get; set; }
        public string ? Password { get; set; }
    }
}
