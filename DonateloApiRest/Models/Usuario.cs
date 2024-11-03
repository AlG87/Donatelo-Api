using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int Rol { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual ICollection<Donacione> DonacioneUsuarioIdBeneficiadoNavigations { get; set; } = new List<Donacione>();

    public virtual ICollection<Donacione> DonacioneUsuarioIdDonanteNavigations { get; set; } = new List<Donacione>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();

    public virtual Roltype RolNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudesDonacion> SolicitudesDonacions { get; set; } = new List<SolicitudesDonacion>();
}
