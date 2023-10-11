using UserService;
using GlobalTypes;
namespace APITemplate.Controllers.UserController.Data
{
    /// <summary>
    /// This class is the model for the add user response.
    /// </summary>
    public class AddUserApiResponse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? First { get; set; }
        public string? Last { get; set; }
        public DateTime Created { get; set; }
        public DateTime ? LastUpdated { get; set; }
        public string ? Email { get; set; }
        public string ? RoleId { get; set; }
    }
}
