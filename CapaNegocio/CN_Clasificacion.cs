using CapaDatos;
using CapaEntidad;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clasificacion
    {
        private CD_Clasificacion objcd_usuario = new CD_Clasificacion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        // Evento para notificar cambios en usuarios
        public event Action OnUsuariosChanged;
        public CN_Clasificacion()
        {
            // Configuración de la conexión a SignalR
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("UsuarioHub");

            // Suscribirse al evento de cambio en SignalR
            usuarioHubProxy.On("ActualizarUsuarios", () => NotifyUsuariosChanged());

            // Iniciar la conexión con SignalR
            hubConnection.Start().Wait();
        }
        public List<Clasificacion> Listar()
        {
            return objcd_usuario.Listar();
        }
        public int Registrar(Clasificacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje = "Es necesario ingresar el nombre de la clasificación";
            }
            if (Mensaje != string.Empty)
                return 0;
            else
                return objcd_usuario.Registrar(obj, out Mensaje);
        }

        public bool Editar(Clasificacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje = "Es necesario ingresar el nombre de la clasificación";
            }
            if (Mensaje != string.Empty)
                return false;
            else
                return objcd_usuario.Editar(obj, out Mensaje);
        }
        public bool Eliminar(Clasificacion obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
        private void NotifyUsuariosChanged()
        {
            // Notificar a la capa de presentación
            OnUsuariosChanged?.Invoke();
        }
    }
}
