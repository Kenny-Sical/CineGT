using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class LogTran
    {
        public string FechaHora { get; set; }
        public Transaccion oTransaccion {  get; set; }
        public string AccionRealizada { get; set; }
        public int IdLogTran { get; set; }
        public Usuario oUsuario { get; set; }
        public Sesion oSesion { get; set; }
        public Usuario otUsuario { get; set; }
    }
}
