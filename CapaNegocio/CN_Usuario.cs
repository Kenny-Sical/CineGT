using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();
        public event Action OnUsuariosChanged;

        public CN_Usuario()
        {
            // Suscribir al evento de cambio en CapaDatos
            objcd_usuario.OnUsuariosChanged += NotifyUsuariosChanged;
        }
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            foreach(PropertyInfo propiedad in obj.GetType().GetProperties())
            {
                if (propiedad.Name == "IDUsuario")
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
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
            {
                if (propiedad.Name == "IDUsuario")
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
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
        private void NotifyUsuariosChanged()
        {
            // Notificar a la capa de presentación
            OnUsuariosChanged?.Invoke();
        }
        public void DetenerTableDependency()
        {
            objcd_usuario.DetenerTableDependency();
        }
    }
}
