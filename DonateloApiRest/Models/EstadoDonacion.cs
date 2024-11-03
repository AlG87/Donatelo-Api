using System;
using System.Collections.Generic;

namespace DonateloApiRest.Models;

public partial class EstadoDonacion
{
    public int EstadoId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();
}
