using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Asiento
    {
        public int IdAsiento { get; set; }
        public int NumeroAsiento { get; set; }
        public string FilaAsiento { get; set; }
        public Sala oSala { get; set; }
        public bool Estado { get; set; }
    }
}
