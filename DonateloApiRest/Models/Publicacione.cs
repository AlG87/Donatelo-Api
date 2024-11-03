using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Publicacione
{
    public int PublicacionId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public int UsuarioId { get; set; }

    public int Estado { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();

    public virtual EstadoPublicacion EstadoNavigation { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
