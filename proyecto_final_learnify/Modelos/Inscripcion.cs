using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify
{
    internal class Inscripcion
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Inscripcion(int id, int alumnoId, int cursoId, DateTime fechaInscripcion)
        {
            Id = id;
            AlumnoId = alumnoId;
            CursoId = cursoId;
            FechaInscripcion = fechaInscripcion;
        }
    }
}
