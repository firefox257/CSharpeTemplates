using GlobalTypes;

namespace APITemplate.Controllers.UserController.Data
{
    /// <summary>
    /// This class is a model for the user login response.
    /// </summary>
    public class LoginUserApiResponse
    {
        public int Id { get; set; }
        public string ? First { get; set; }
        public string ? Last { get; set; }
        public string ? Email { get; set; }
        public string ? RoleId { get; set; }
        public string ? AuthToken { get; set; }
    }
}
