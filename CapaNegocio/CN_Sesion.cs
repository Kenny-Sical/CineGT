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
    public class CN_Sesion
    {
        private CD_Sesion obj_sesion = new CD_Sesion();
        private HubConnection hubConnection;
        private IHubProxy usuarioHubProxy;
        // Evento para notificar cambios en usuarios
        public event Action OnChanged;
        public CN_Sesion()
        {
            // Configuración de la conexión a SignalR
            hubConnection = new HubConnection("http://26.21.190.108:8080");
            usuarioHubProxy = hubConnection.CreateHubProxy("ConeccionHub");

            // Suscribirse al evento de cambio en SignalR
            usuarioHubProxy.On("Actualizar", () => NotifyChanged());

            // Iniciar la conexión con SignalR
            hubConnection.Start().Wait();
        }
        public List<Sesion> Listar()
        {
            return obj_sesion.Listar();
        }
        public int Registrar(Sesion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
            {
                if (propiedad.Name == "IdSesion")
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
                return obj_sesion.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Sesion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
            {
                if (propiedad.Name == "IdSesion")
                    continue;

                if (propiedad.Name == "Clave")
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
                return false;
            }
            else
            {
                return obj_sesion.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Sesion obj, out string Mensaje)
        {
            return obj_sesion.Eliminar(obj, out Mensaje);
        }
        private void NotifyChanged()
        {
            // Notificar a la capa de presentación
            OnChanged?.Invoke();
        }
    }
}
