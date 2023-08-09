using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Security.PasswordHasher;

namespace TudoHorroroso.Controllers;

using Model;
using Repositories;
using DTO;
using Security.Jwt;
using Microsoft.AspNetCore.Identity;

[ApiController]
[EnableCors("MainPolicy")]
[Route("user")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(
        [FromServices] IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }


    [HttpPost("register")]
    public async Task<ActionResult> Register(
        [FromBody] RegisterDTO data,
        [FromServices] IPasswordHasher psh)
    {
        Console.WriteLine("chegou aqui");

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

    [HttpPost("login")]
    public async Task<ActionResult> Login(
        [FromBody] LoginDTO data,
        [FromServices] IUserRepository userRepository,
        [FromServices] IPasswordHasher psh,
        [FromServices] IJwtService jwtService
        )
    {
        User user = await userRepository.FindByEmail(data.Email);

        if (user is null)
            return NotFound();

        var validate = psh.Validate(data.Password, user.Salt, user.HashCode);

        if (!validate)
            return Forbid();

        string jwt = jwtService.GetToken(new UserToken { UserID = user.Id });
        Jwt result = new() { Value = jwt };

        return Ok(result);
    }
}

