using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Sala
    {
        private CD_Sala objcd_sala = new CD_Sala();

        public List<Sala> Listar()
        {
            return objcd_sala.Listar();
        }
    }
}
