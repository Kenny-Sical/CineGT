using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set;}
        public int IDUsuario { get; set; }
        public string Clave { get; set;}
        public Rol oRol { get; set; }
    }
}
