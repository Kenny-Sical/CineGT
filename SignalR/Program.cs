using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SignalR
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = "http://26.21.190.108:8080"; // Cambia el puerto si es necesario
            using (WebApp.Start(url))
            {
                Console.WriteLine("Servidor SignalR ejecutándose en " + url);
                Console.ReadLine(); // Mantiene la consola abierta
            }
        }
    }
}
