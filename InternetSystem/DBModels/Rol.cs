using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Rol
{
    public int Rolid { get; set; }

    public string Rolname { get; set; } = null!;

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
