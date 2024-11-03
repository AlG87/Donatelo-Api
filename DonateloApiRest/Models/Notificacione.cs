﻿using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Notificacione
{
    public int NotificacionId { get; set; }

    public int UsuarioId { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public bool? Leido { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}