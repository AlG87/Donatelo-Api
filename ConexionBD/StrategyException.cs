using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class StrategyException : Exception
    {
        public StrategyException() : base() { }

        public StrategyException(string message) : base(message) { }

        public StrategyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
