using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class SolicitudesDonacion
{
    public int SolicitudId { get; set; }

    public int? DonacionId { get; set; }

    public int? BeneficiadoId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public virtual Usuario? Beneficiado { get; set; }

    public virtual Donacione? Donacion { get; set; }

    public virtual EstadoPublicacion? Estado { get; set; }
}
