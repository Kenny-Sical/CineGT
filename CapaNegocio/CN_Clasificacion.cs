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
        private CD_Clasificacion objcd_clasificacion = new CD_Clasificacion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        // Evento para notificar cambios en usuarios
        public event Action OnChanged;
        public CN_Clasificacion()
        {
            // Configuración de la conexión a SignalR
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");

            // Suscribirse al evento de cambio en SignalR
            usuarioHubProxy.On("Actualizar", () => NotifyClasificacionChanged());

            // Iniciar la conexión con SignalR
            hubConnection.Start().Wait();
        }
        public List<Clasificacion> Listar()
        {
            return objcd_clasificacion.Listar();
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
                return objcd_clasificacion.Registrar(obj, out Mensaje);
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
                return objcd_clasificacion.Editar(obj, out Mensaje);
        }
        public bool Eliminar(Clasificacion obj, out string Mensaje)
        {
            return objcd_clasificacion.Eliminar(obj, out Mensaje);
        }
        private void NotifyClasificacionChanged()
        {
            // Notificar a la capa de presentación
            OnChanged?.Invoke();
        }
    }
}
