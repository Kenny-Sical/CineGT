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
    public class CN_Transaccion
    {
        private CD_Transaccion objcd_transaccion = new CD_Transaccion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        // Evento para notificar cambios en usuarios
        public event Action OnChanged;
        public CN_Transaccion()
        {
            // Configuración de la conexión a SignalR
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");

            // Suscribirse al evento de cambio en SignalR
            usuarioHubProxy.On("Actualizar", () => NotifyChanged());

            // Iniciar la conexión con SignalR
            hubConnection.Start().Wait();
        }
        public List<Transaccion> Listar()
        {
            return objcd_transaccion.Listar();
        }
        public int Registrar(Transaccion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
            {
                if (propiedad.Name == "IdTransaccion")
                    continue;

                // Obtiene el valor de la propiedad
                var valor = propiedad.GetValue(obj);

                // Verifica si la propiedad es de tipo string y está vacía
                if (valor is string strValor && string.IsNullOrWhiteSpace(strValor))
                {
                    Mensaje = $"El campo {propiedad.Name} no puede estar vacío.";
                }

                // Verifica si la propiedad es nula (para el caso de propiedades de tipo referencia)
                if (valor == null)
                {
                    Mensaje = $"El campo {propiedad.Name} no puede ser nulo.";
                }
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_transaccion.Registrar(obj, out Mensaje);
            }
        }
        private void NotifyChanged()
        {
            // Notificar a la capa de presentación
            OnChanged?.Invoke();
        }
    }
}
