using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify.BaseDeDatos
{
    internal class TablaInscripcion
    {
        private static readonly string conexion = "Server=localhost;Database=usuarios_learnify;User Id=root;Password=;";

        public static bool Inscribirse(int alumnoId, int cursoId)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "INSERT INTO inscripcion (AlumnoId, CursoId, FechaInscripcion) VALUES (@alumnoId, @cursoId, @fecha)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@alumnoId", MySqlDbType.Int32).Value = alumnoId;
                    cmd.Parameters.Add("@cursoId", MySqlDbType.Int32).Value = cursoId;
                    cmd.Parameters.Add("@fecha", MySqlDbType.DateTime).Value = DateTime.Now;

                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }

        public static bool EstaInscrito(int alumnoId, int cursoId)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT COUNT(*) FROM inscripcion WHERE AlumnoId=@alumnoId AND CursoId=@cursoId";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@alumnoId", MySqlDbType.Int32).Value = alumnoId;
                    cmd.Parameters.Add("@cursoId", MySqlDbType.Int32).Value = cursoId;

                    con.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public static List<int> ObtenerCursosDeAlumno(int alumnoId)
        {
            List<int> listaCursos = new List<int>();

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT CursoId FROM inscripcion WHERE AlumnoId=@alumnoId";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@alumnoId", MySqlDbType.Int32).Value = alumnoId;

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCursos.Add(Convert.ToInt32(reader["CursoId"]));
                        }
                    }
                }
            }
            return listaCursos;
        }

        public static List<Curso> ObtenerCursosPorAlumno(int alumnoId)
        {
            List<Curso> cursos = new List<Curso>();

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = @"SELECT c.id, c.nombre, c.descripcion, c.ProfesorId, c.FechaPublicacion, c.rutaArchivo
                                 FROM inscripcion i
                                 INNER JOIN cursos c ON i.CursoId = c.id
                                 WHERE i.AlumnoId = @alumnoId";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@alumnoId", alumnoId);

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Curso curso = new Curso(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["descripcion"].ToString(),
                                Convert.ToInt32(reader["ProfesorId"]),
                                Convert.ToDateTime(reader["FechaPublicacion"]),
                                reader["rutaArchivo"].ToString()
                            );
                            cursos.Add(curso);
                        }
                    }
                }
            }
            return cursos;
        }

        public static bool EliminarInscripcion(int alumnoId, int cursoId)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "DELETE FROM inscripcion WHERE AlumnoId=@alumnoId AND CursoId=@cursoId";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@alumnoId", MySqlDbType.Int32).Value = alumnoId;
                    cmd.Parameters.Add("@cursoId", MySqlDbType.Int32).Value = cursoId;

                    con.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }
    }
}
