using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR
{
    public class UsuarioHub:Hub
    {
        public void NotificarCambioUsuarios()
        {
            Clients.All.ActualizarUsuarios();
        }
    }
}
