using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class SeguimientoDonacionDto
    {
        public int SeguimientoId { get; set; }
        public int DonacionId { get; set; }
        public int SedeId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}
