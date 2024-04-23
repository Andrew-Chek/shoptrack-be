using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Route("api/users")]
public class UserController : CrudController<User, UserRepository>
{
    public UserController(UserRepository userRepository) : base(userRepository)
    {
    }

    [HttpGet("{id}")]
    [Authorize]
    public override async Task<IActionResult> GetById(int id)
    {
        return await base.GetById(id);
    }
}
