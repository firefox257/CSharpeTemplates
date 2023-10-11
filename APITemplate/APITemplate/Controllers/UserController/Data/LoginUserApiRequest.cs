namespace APITemplate.Controllers.UserController.Data
{
    /// <summary>
    /// This class is a model for the user login. 
    /// </summary>
    public class LoginUserApiRequest
    {
        public string ? UserName { get; set; }
        public string ? Email { get; set; }
        public string ? Password { get; set; }
    }
}
