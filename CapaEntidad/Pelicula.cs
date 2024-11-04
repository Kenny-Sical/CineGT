using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public TimeSpan Duracion { get; set; }
        public Clasificacion oClasificacion { get; set; }
    }
}
