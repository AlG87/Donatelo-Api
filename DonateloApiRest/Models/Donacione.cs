using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Donacione
{
    public int DonacionId { get; set; }

    public int UsuarioIdDonante { get; set; }

    public int? UsuarioIdBeneficiado { get; set; }

    public int? PublicacionId { get; set; }

    public string MetodoEntrega { get; set; } = null!;

    public int? SedeId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int Estado { get; set; }

    public virtual EstadoDonacion EstadoNavigation { get; set; } = null!;

    public virtual Publicacione? Publicacion { get; set; }

    public virtual Sede? Sede { get; set; }

    public virtual ICollection<SolicitudesDonacion> SolicitudesDonacions { get; set; } = new List<SolicitudesDonacion>();

    public virtual Usuario? UsuarioIdBeneficiadoNavigation { get; set; }

    public virtual Usuario UsuarioIdDonanteNavigation { get; set; } = null!;
}
