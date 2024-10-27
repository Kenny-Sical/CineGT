using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Transaccion
    {
        public int IdTransaccion {  get; set; }
        public int NumeroTransaccion { get; set; }
        public string FechaHora { get; set; }
        public Accion oAccion { get; set; }
    }
}
