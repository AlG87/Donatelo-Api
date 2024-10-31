using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class PublicacionDto
    {
        public int PublicacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int UsuarioId { get; set; }
        public int Estado { get; set; }
        public string ImagenUrl { get; set; }
    }
}
