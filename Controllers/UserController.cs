using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/users")]
public class UserController : CrudController<User, UserRepository>
{
    public UserController(UserRepository userRepository) : base(userRepository)
    {
    }
}
