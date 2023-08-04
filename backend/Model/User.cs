using System;
using System.Collections.Generic;

namespace TudoHorroroso.Model;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public byte[] HashCode { get; set; }

    public string Salt { get; set; }

    public string Email { get; set; }
}
