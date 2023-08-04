using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Security.PasswordHasher;

namespace TudoHorroroso.Controllers;

using Model;
using Repositories;
using DTO;

[ApiController]
[EnableCors("MainPolicy")]
[Route("user")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(
        [FromServices] IUserRepository userRepository
        )
    {
        this.userRepository = userRepository;
    }


    [HttpPost("register")]
    public async Task<ActionResult> Register(
        [FromBody] RegisterDTO data,
        [FromServices] IPasswordHasher psh
    )
    {
        if (!await userRepository.IsValid(new() { Email = data.Email, UserName = data.UserName }))
            return BadRequest();

        byte[] hashpw;
        string salt;

        (hashpw, salt) = psh.GetHashAndSalt(data.Password);

        User u = new()
        {
            UserName = data.UserName,
            Email = data.Email,
            HashCode = hashpw,
            Salt = salt
        };

        await this.userRepository.Add(u);

        return Ok();
    }
}

