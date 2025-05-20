using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_learnify.BaseDeDatos
{
    internal class CrearBaseDatos
    {
        static string con = "Server=localhost;Port=3306;User Id=usuario;Password=;";
        public static void CrearBaseDato()
        {
            MySqlConnection conexion = new MySqlConnection(con);
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS usuarios_learnify CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;", conexion);
            cmd.ExecuteNonQuery();
        }

        public static void CrearTablas()
        {
            MySqlConnection conexion = new MySqlConnection(con);
            conexion.Open();

            string tablaUsuarios = @"CREATE TABLE IF NOT EXISTS usuarios (
                id INT AUTO_INCREMENT PRIMARY KEY,
                nombre VARCHAR(50),
                apellidos VARCHAR(50),
                edad INT,
                nombre_usuario VARCHAR(50) UNIQUE,
                gmail VARCHAR(100) UNIQUE,
                contrasenna VARCHAR(100),
                nacimiento DATE,
                tipo ENUM('profesor', 'alumno')
                ) ENGINE=InnoDB;";

            string tablaCursos = @"CREATE TABLE IF NOT EXISTS cursos (
                id INT AUTO_INCREMENT PRIMARY KEY,
                nombre VARCHAR(100),
                descripcion TEXT,
                profesorId INT,
                fechaPublicacion DATE,
                archivo VARCHAR(255),
                FOREIGN KEY (profesorId) REFERENCES usuarios(id)
                ) ENGINE=InnoDB;";

            string tablaInscripciones = @"CREATE TABLE IF NOT EXISTS inscripciones (
                id INT AUTO_INCREMENT PRIMARY KEY,
                alumnoId INT,
                cursoId INT,
                fechaInscripcion DATE,
                FOREIGN KEY (alumnoId) REFERENCES usuarios(id),
                FOREIGN KEY (cursoId) REFERENCES cursos(id)
                ) ENGINE=InnoDB;";

            MySqlCommand cmd1 = new MySqlCommand(tablaUsuarios, conexion);
            MySqlCommand cmd2 = new MySqlCommand(tablaCursos, conexion);
            MySqlCommand cmd3 = new MySqlCommand(tablaInscripciones, conexion);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
        }
    }
}
