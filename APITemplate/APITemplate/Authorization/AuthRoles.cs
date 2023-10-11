using GlobalTypes;
namespace APITemplate.Authorization
{
    /// <summary>
    /// Attribute to allow certian roles to be allowed to access the end point.
    /// </summary>
    public class AuthRoles : Attribute
    {
        public string[] Types { get; set; }
        public AuthRoles(params string[] roleTypes)
        {
            Types =roleTypes;
        }
         
    }
}
