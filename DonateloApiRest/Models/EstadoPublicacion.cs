using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class EstadoPublicacion
{
    public int EstadoId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();

    public virtual ICollection<SolicitudesDonacion> SolicitudesDonacions { get; set; } = new List<SolicitudesDonacion>();
}
