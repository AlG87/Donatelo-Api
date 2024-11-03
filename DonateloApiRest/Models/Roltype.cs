﻿using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Roltype
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
