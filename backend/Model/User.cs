using System;
using System.Collections.Generic;

namespace TudoHorroroso.Model;

public partial class User
{
    public string UserName { get; set; }

    public string HashCode { get; set; }

    public string Salt { get; set; }

    public string Email { get; set; }
}
