using TudoHorroroso.Model;

namespace TudoHorroroso.DTO;

public class LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}

//public class Jwt
//{
//    public string Value { get; set; }
//}

public class UserToken
{
    public int UserID { get; set; }
}

