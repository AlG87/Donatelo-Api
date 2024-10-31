using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class SolicitudesDonacionDto
    {
        public int solicitudId { get; set; }
        public int donacionid { get; set; } 
        public int beneficiadoid { get; set; }
        public int Estado { get; set; }
        public DateTime fechaSolicitud { get; set; }
    }
}
