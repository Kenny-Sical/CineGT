using CapaDatos;
using CapaEntidad;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_VentayTransaccion
    {
        private CD_VentayTransaccion objcd_venta = new CD_VentayTransaccion();
        public int Registrar(DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_venta.Registrar(DetalleCompra, out Mensaje);
        }
        public bool Anular(DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_venta.Anular(DetalleCompra, out Mensaje);
        }
        public bool CambiarAsiento(DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_venta.CambiarAsiento(DetalleCompra, out Mensaje);
        }
        public List<Venta> ObtenerVentaPorTransaccion(int numerotransaccion)
        {
            return objcd_venta.ObtenerVentaPorTransaccion(numerotransaccion);
        }
    }
}
