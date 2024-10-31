using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class NotificacionesDto
    {
        public int Notificacionid { get; set; }
        public int usuariod { get; set; }
        public string Mnesaje { get; set; }
        public DateTime Fecha { get; set; }
        public bool Leido { get; set; }
    }
}
