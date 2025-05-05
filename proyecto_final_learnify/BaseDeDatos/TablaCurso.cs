using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify.BaseDeDatos
{
    internal class TablaCurso
    {
        private static readonly string conexion = "Server=localhost;Database=usuarios_learnify;User Id=root;Password=;";

        public static bool CrearCurso(Curso curso)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "INSERT INTO cursos (nombre, descripcion, profesorId, fechaPublicacion, rutaArchivo) VALUES (@nombre, @descripcion, @profesorId, @fechaPublicacion, @rutaArchivo)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", curso.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", curso.Descripcion);
                    cmd.Parameters.AddWithValue("@profesorId", curso.ProfesorId);
                    cmd.Parameters.AddWithValue("@fechaPublicacion", curso.FechaPublicacion);
                    cmd.Parameters.AddWithValue("@rutaArchivo", curso.RutaArchivo);

                    con.Open();
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
        }

        public static List<Curso> ObtenerCursosPorProfesor(int profesorId)
        {
            List<Curso> lista = new List<Curso>();

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT id, nombre, descripcion, profesorId, fechaPublicacion FROM cursos WHERE profesorId = @profesorId";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@profesorId", profesorId);

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Curso curso = new Curso(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["descripcion"].ToString(),
                                Convert.ToInt32(reader["profesorId"]),
                                Convert.ToDateTime(reader["fechaPublicacion"]),
                                reader["tipoPublicacion"].ToString()
                            );
                            lista.Add(curso);
                        }
                    }
                }
            }

            return lista;
        }

        public static Curso ObtenerCursoPorId(int id)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT * FROM cursos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Curso(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["descripcion"].ToString(),
                                Convert.ToInt32(reader["profesorId"]),
                                Convert.ToDateTime(reader["fechaPublicacion"]),
                                reader["tipoPublicacion"].ToString()
                            );
                        }
                    }
                }
            }

            return null;
        }
    
        public static bool EliminarCurso(int id)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "DELETE FROM cursos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
        }
    }
}
