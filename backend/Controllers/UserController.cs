using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Security.PasswordHasher;

namespace TudoHorroroso.Controllers;

using Model;
using Repositories;
using DTO;
using Security.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Login(
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


        // TODO Password Service
        //if (!validate)
        //    return Forbid();

        string jwt = jwtService.GetToken(new UserToken { UserID = user.Id });
        dynamic result = new { token = jwt };

        return Ok(result);
    }

    [HttpGet("auth")]
    [Authorize]
    public string Authenticated() => "Autenticado";
}

