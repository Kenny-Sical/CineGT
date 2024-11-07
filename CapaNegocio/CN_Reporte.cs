using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_reporte = new CD_Reporte();

        // Reporte 1
        public DataTable ObtenerReporte1(DateTime fechaInicio, DateTime fechaFin, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (fechaInicio > fechaFin)
            {
                Mensaje = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            return objcd_reporte.ObtenerReporte1(fechaInicio, fechaFin);
        }

        // Reporte 2
        public DataTable ObtenerReporte2(DateTime fechaInicio, DateTime fechaFin, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (fechaInicio > fechaFin)
            {
                Mensaje = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            return objcd_reporte.ObtenerReporte2(fechaInicio, fechaFin);
        }

        // Reporte 3
        public DataTable ObtenerReporte3(string nombreSala, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(nombreSala))
            {
                Mensaje = "El nombre de la sala no puede estar vacío.";
                return null;
            }
            return objcd_reporte.ObtenerReporte3(nombreSala);
        }

        // Reporte 4
        public DataTable ObtenerReporte4(int porcentajeOcupacion, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (porcentajeOcupacion < 0 || porcentajeOcupacion > 100)
            {
                Mensaje = "El porcentaje de ocupación debe estar entre 0 y 100.";
                return null;
            }
            return objcd_reporte.ObtenerReporte4(porcentajeOcupacion);
        }

        // Reporte 5
        public DataTable ObtenerReporte5(out string Mensaje)
        {
            Mensaje = string.Empty;
            return objcd_reporte.ObtenerReporte5();
        }

        // Reporte 6
        public DataTable ObtenerReporte6(DateTime fechaInicio, DateTime fechaFin, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (fechaInicio > fechaFin)
            {
                Mensaje = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            return objcd_reporte.ObtenerReporte6(fechaInicio, fechaFin);
        }

        // Reporte 7
        public DataTable ObtenerReporte7(DateTime fechaInicio, DateTime fechaFin, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (fechaInicio > fechaFin)
            {
                Mensaje = "La fecha de inicio no puede ser posterior a la fecha de fin.";
                return null;
            }
            return objcd_reporte.ObtenerReporte7(fechaInicio, fechaFin);
        }
    }
}
