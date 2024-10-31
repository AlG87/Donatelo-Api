using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class SedeDto
    {
        public int SedeId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string ImagenUrl { get; set; }
    }
}
