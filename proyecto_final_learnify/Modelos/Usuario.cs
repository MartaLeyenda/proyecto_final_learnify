using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Nombre_usuario { get; set; }
        public string Gmail { get; set; }
        public string Contrasenna { get; set; }
        public DateTime Nacimiento { get; set; }
        public enum TipoUsuario { profesor, alumno }
        public TipoUsuario Tipo { get; set; }
        
        public Usuario(string nombre, string apellidos, int edad, string nombre_usuario, string gmail, string contrasenna, DateTime nacimiento, TipoUsuario tipo)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Nombre_usuario = nombre_usuario;
            Gmail = gmail;
            Contrasenna = contrasenna;
            Nacimiento = nacimiento;
            Tipo = tipo;
        }
    }
}
