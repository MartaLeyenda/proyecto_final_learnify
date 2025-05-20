using proyecto_final_learnify.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_learnify.Formularios
{
    public partial class VerCursosForm : Form
    {
        private int idAlumno;
        public VerCursosForm(int alumnoId)
        {
            InitializeComponent();
            idAlumno = alumnoId;
            CargarCursos();
        }

        private void CargarCursos(string filtro = "")
        {
            flpCursos.Controls.Clear();

            List<Curso> cursos = TablaCurso.ObtenerTodosLosCursos(filtro);

            foreach (Curso curso in cursos)
            {
                Panel panel = CrearTarjetaCurso(curso);
                flpCursos.Controls.Add(panel);
            }
        }

        private Panel CrearTarjetaCurso(Curso curso)
        {
            Panel panel = new Panel
            {
                Size = new Size(500, 150),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblTitulo = new Label
            {
                Text = curso.Nombre,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblDescripcion = new Label
            {
                Text = curso.Descripcion.Length > 200 ? curso.Descripcion.Substring(0, 200) + "..." : curso.Descripcion,
                Location = new Point(10, 40),
                Size = new Size(350, 40)
            };

            Button btnVerArchivo = new Button
            {
                Text = "Ver archivo",
                Location = new Point(370, 40),
                Size = new Size(100, 30)
            };
            btnVerArchivo.Click += (s, e) => AbrirArchivo(curso.RutaArchivo);

            Button btnInscribirse = new Button
            {
                Text = "Inscribirme",
                Location = new Point(370, 80),
                Size = new Size(100, 30)
            };
            btnInscribirse.Click += (s, e) =>
            {
                if (TablaInscripcion.Inscribirse(idAlumno, curso.Id))
                {
                    MessageBox.Show("Inscripción exitosa.");
                }
                else
                {
                    MessageBox.Show("Ya estás inscrito o ocurrió un error.");
                }
            };

            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblDescripcion);
            panel.Controls.Add(btnVerArchivo);
            panel.Controls.Add(btnInscribirse);

            return panel;
        }

        private void AbrirArchivo(string ruta)
        {
            string carpetaArchivos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos");
            string rutaCompleta = Path.Combine(carpetaArchivos, ruta);

            if (File.Exists(rutaCompleta))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaCompleta,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("El archivo no se encontró.");
            }
        }

        private void btnCerrarSesion_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Learnify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnBuscar_click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarCursos(filtro);
        }

        private void btnMisInscripciones_click(object sender, EventArgs e)
        {            
            MisCursosForm misCursos = new MisCursosForm(idAlumno);
            misCursos.ShowDialog();
        }

        private void btnConectarse_click(object sender, EventArgs e)
        {
            ClienteForm cliente = new ClienteForm();
            cliente.Show();
        }
    }
}
