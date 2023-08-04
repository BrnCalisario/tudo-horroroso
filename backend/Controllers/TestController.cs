using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TudoHorroroso.Controllers;


[ApiController]
[EnableCors("MainPolicy")]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
        => Ok();

}
