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
    public partial class MisCursosForm : Form
    {
        private int alumnoId;
        public MisCursosForm(int alumnoId)
        {
            InitializeComponent();
            this.alumnoId = alumnoId;
            CargarCursosInscritos();
        }

        private void CargarCursosInscritos()
        {
            var cursos = TablaInscripcion.ObtenerCursosPorAlumno(alumnoId);
            flpCursos.Controls.Clear();

            foreach (var curso in cursos)
            {
                Panel panel = new Panel
                {
                    Width = 400,
                    Height = 220,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(10)
                };

                Label lblNombre = new Label
                {
                    Text = curso.Nombre,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 25
                };

                Label lblDescripcion = new Label
                {
                    Text = curso.Descripcion,
                    AutoSize = false,
                    Height = 60,
                    Dock = DockStyle.Top
                };

                Label lblFecha = new Label
                {
                    Text = $"Publicado el: {curso.FechaPublicacion.ToShortDateString()}",
                    Dock = DockStyle.Top
                };

                Button btnAbrirArchivo = new Button
                {
                    Text = "Abrir archivo",
                    Width = 120,
                    Height = 30,
                    Top = 140,
                    Left = 10
                };
                btnAbrirArchivo.Click += (s, e) =>
                {
                    if (File.Exists(curso.RutaArchivo))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = curso.RutaArchivo,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("El archivo no se encuentra disponible.");
                    }
                };

                Button btnEliminarInscripcion = new Button
                {
                    Text = "Eliminar inscripción",
                    Width = 150,
                    Height = 30,
                    Top = 140,
                    Left = 140
                };
                btnEliminarInscripcion.Click += (s, e) =>
                {
                    DialogResult result = MessageBox.Show("¿Deseas darte de baja de este curso?", "Confirmar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TablaInscripcion.EliminarInscripcion(alumnoId, curso.Id);
                        CargarCursosInscritos();
                    }
                };

                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblDescripcion);
                panel.Controls.Add(lblFecha);
                panel.Controls.Add(btnAbrirArchivo);
                panel.Controls.Add(btnEliminarInscripcion);

                flpCursos.Controls.Add(panel);
            }
        }

        private void btnVolver_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
