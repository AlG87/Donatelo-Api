using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatelo.Api.Entities
{
    public class SedeStockDto
    {
        public int SedeStockId { get; set; }
        public int SedeId { get; set; }
        public int DonacionId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
