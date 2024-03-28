using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Creationdate { get; set; }

    public int RolRolid { get; set; }

    public string? UserstatusStatusid { get; set; }

    public virtual Rol RolRol { get; set; } = null!;

    public virtual ICollection<Usercash> Usercashes { get; set; } = new List<Usercash>();

    public virtual Userstatus? UserstatusStatus { get; set; }
}
