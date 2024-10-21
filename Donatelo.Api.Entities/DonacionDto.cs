using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class DonacionDto
    {
        public int DonacionId { get; set; }
        public int PublicacionId { get; set; }
        public int BeneficiadoId { get; set; }
        public int DonanteId { get; set; }
        public DateTime FechaDonacion { get; set; }
        public int MetodoEntregaId { get; set; }
        public string Estado { get; set; }
    }
}
