using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int idVenta {  get; set; }
        public string TipoAsignacion { get; set; }
        public Transaccion oTransaccion { get; set; }
        public Sesion oSesion { get; set; }
        public Asiento oAsiento { get; set; }
        public Usuario oUsuario { get; set; }
    }
}
