using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify
{
    internal class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ProfesorId { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Curso(int id, string nombre, string descripcion, int profesorId, DateTime fechaPublicacion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            ProfesorId = profesorId;
            FechaPublicacion = fechaPublicacion;
        }
    }
}
