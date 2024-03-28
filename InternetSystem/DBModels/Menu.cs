using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Menu
{
    public int Menuid { get; set; }

    public string? Icon { get; set; }

    public string Description { get; set; } = null!;

    public int RolRolid { get; set; }

    public virtual Rol RolRol { get; set; } = null!;
}
