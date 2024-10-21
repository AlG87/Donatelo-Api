using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class AplicacionDto
    {
        public int AplicacionId { get; set; }
        public int PublicacionId { get; set; }
        public int BeneficiadoId { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public string Estado { get; set; }
    }
}
