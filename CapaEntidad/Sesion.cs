﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Sesion
    {
        public int IdSesion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public int Estado {  get; set; }
        public DateTime FechaHoraFin {  get; set; }
        public Sala oSala { get; set; }
        public Pelicula oPelicula { get; set; }
    }
}
