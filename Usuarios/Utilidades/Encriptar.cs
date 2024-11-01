using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Utilidades
{
    public class Encriptar
    {
        public static string EncriptarSHA256(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convertir los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
