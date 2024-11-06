using CapaDatos;
using CapaEntidad;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Asiento
    {
        private CD_Asiento objcd_Asiento = new CD_Asiento();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        // Evento para notificar cambios en usuarios
        public event Action OnChanged;
        public CN_Asiento()
        {
            // Configuración de la conexión a SignalR
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");

            // Suscribirse al evento de cambio en SignalR
            usuarioHubProxy.On("Actualizar", () => NotifyChanged());

            // Iniciar la conexión con SignalR
            hubConnection.Start().Wait();
        }
        private void NotifyChanged()
        {
            // Notificar a la capa de presentación
            OnChanged?.Invoke();
        }
        public List<Asiento> Listar(int sala)
        {
            return objcd_Asiento.Listar(sala);
        }
        public List<Asiento> ListarOcupados(int sesion, int sala)
        {
            return objcd_Asiento.ListarOcupados(sesion, sala);
        }
    }
}
