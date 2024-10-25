using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class StrategyError
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public StrategyError(int id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
