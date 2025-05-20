using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                    try
                    {
                        con.Open();
                        int resultado = cmd.ExecuteNonQuery();
                        return resultado > 0;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al crear el curso: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static List<Curso> ObtenerCursosPorProfesor(int profesorId)
        {
            List<Curso> lista = new List<Curso>();

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT id, nombre, descripcion, profesorId, fechaPublicacion, RutaArchivo FROM cursos WHERE profesorId = @profesorId";

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
                                reader["RutaArchivo"].ToString()
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
                                reader["RutaArchivo"].ToString()
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

        public static List<Curso> ObtenerTodosLosCursos(string filtro = "")
        {
            List<Curso> cursos = new List<Curso>();
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT id, nombre, descripcion, profesorId, fechaPublicacion, rutaArchivo FROM cursos";
                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " WHERE nombre LIKE @filtro OR descripcion LIKE @filtro";
                }
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Curso curso = new Curso(
                                id: Convert.ToInt32(reader["id"]),
                                nombre: reader["nombre"].ToString(),
                                descripcion: reader["descripcion"].ToString(),
                                profesorId: Convert.ToInt32(reader["profesorId"]),
                                fechaPublicacion: Convert.ToDateTime(reader["fechaPublicacion"]),
                                rutaArchivo: reader["rutaArchivo"].ToString()
                            );
                            cursos.Add(curso);
                        }
                    }
                }
            }
            return cursos;
        }
    }
}
