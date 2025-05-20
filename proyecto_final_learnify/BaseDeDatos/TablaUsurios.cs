using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify.BaseDeDatos
{
    internal class TablaUsurios
    {
        private static readonly string conexion = "Server=localhost;Database=usuarios_learnify;User Id=root;Password=;";

        public TablaUsurios() { }

        public static bool añadirUsuario(Usuario usuario)
        {
            if (existeUsuario(usuario.Nombre_usuario, usuario.Gmail)) return false;

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "INSERT INTO usuarios (nombre, apellidos, edad, nombre_usuario, gmail, contrasenna, nacimiento, tipo) " +
                           "VALUES (@nombre, @apellidos, @edad, @nombre_usuario, @gmail, @contrasenna, @nacimiento, @tipo)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar).Value = usuario.Apellidos;
                    cmd.Parameters.Add("@edad", MySqlDbType.Int32).Value = usuario.Edad;
                    cmd.Parameters.Add("@nombre_usuario", MySqlDbType.VarChar).Value = usuario.Nombre_usuario;
                    cmd.Parameters.Add("@gmail", MySqlDbType.VarChar).Value = usuario.Gmail;
                    cmd.Parameters.Add("@contrasenna", MySqlDbType.VarChar).Value = usuario.Contrasenna;
                    cmd.Parameters.Add("@nacimiento", MySqlDbType.Date).Value = usuario.Nacimiento.Date;
                    cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = usuario.Tipo.ToString();

                    con.Open();
                    int cantidad = cmd.ExecuteNonQuery();
                    return cantidad > 0;
                }
            }
        }

        public static bool existeUsuario(string nombreUsuario, string gmail)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario=@nombre_usuario OR gmail=@gmail";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@nombre_usuario", MySqlDbType.VarChar).Value = nombreUsuario;
                    cmd.Parameters.Add("@gmail", MySqlDbType.VarChar).Value = gmail;

                    con.Open();
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public static Usuario ObtenerUsuarioId(int id)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT nombre, apellidos, edad, nombre_usuario, gmail, contrasenna, nacimiento, tipo " +
                               "FROM usuarios WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Usuario.TipoUsuario tipo = (Usuario.TipoUsuario)Enum.Parse(
                                typeof(Usuario.TipoUsuario),
                                reader["tipo"].ToString()
                            );

                            Usuario usuario = new Usuario(
                                reader["nombre"].ToString(),
                                reader["apellidos"].ToString(),
                                Convert.ToInt32(reader["edad"]),
                                reader["nombre_usuario"].ToString(),
                                reader["gmail"].ToString(),
                                reader["contrasenna"].ToString(),
                                Convert.ToDateTime(reader["nacimiento"]),
                                tipo
                            );

                            return usuario;
                        }
                    }
                }
            }
            return null;
        }

        public static Usuario ObtenerUsuarioPorCredenciales(string nombreUsuario, string contrasenna)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                string query = "SELECT id, nombre, apellidos, edad, nombre_usuario, gmail, contrasenna, nacimiento, tipo FROM usuarios WHERE nombre_usuario = @nombre_usuario AND contrasenna = @contrasenna";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@nombre_usuario", MySqlDbType.VarChar).Value = nombreUsuario;
                    cmd.Parameters.Add("@contrasenna", MySqlDbType.VarChar).Value = contrasenna;

                    con.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Usuario.TipoUsuario tipo = (Usuario.TipoUsuario)Enum.Parse(
                                typeof(Usuario.TipoUsuario),
                                reader["tipo"].ToString()
                            );

                            Usuario usuario = new Usuario(
                                Convert.ToInt32(reader["id"]),
                                reader["nombre"].ToString(),
                                reader["apellidos"].ToString(),
                                Convert.ToInt32(reader["edad"]),
                                reader["nombre_usuario"].ToString(),
                                reader["gmail"].ToString(),
                                reader["contrasenna"].ToString(),
                                Convert.ToDateTime(reader["nacimiento"]),
                                tipo
                            );
                            return usuario;
                        }
                    }
                }
            }
            return null;
        }

    }
}
