using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Sede
{
    public int SedeId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? ImagenUrl { get; set; }

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();
}
