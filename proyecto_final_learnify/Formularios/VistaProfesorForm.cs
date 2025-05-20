using proyecto_final_learnify.BaseDeDatos;
using proyecto_final_learnify.Formularios;
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

namespace proyecto_final_learnify.Páginas
{
    public partial class VistaProfesorForm : Form
    {
        private int profesorId;
        public VistaProfesorForm(int idProfesor)
        {
            InitializeComponent();
            profesorId = idProfesor;
            CargarCursos();
        }

        private void CargarCursos()
        {
            pnlCursos.Controls.Clear();
            List<Curso> cursos = TablaCurso.ObtenerCursosPorProfesor(profesorId);

            foreach (Curso curso in cursos)
            {
                Panel panelCurso = new Panel();
                panelCurso.BorderStyle = BorderStyle.FixedSingle;
                panelCurso.Size = new Size(300, 150);
                panelCurso.Margin = new Padding(10);
                panelCurso.BackColor = Color.White;

                Label lblTitulo = new Label
                {
                    Text = curso.Nombre,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Size = new Size(280, 25),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblDescripcion = new Label
                {
                    Text = curso.Descripcion.Length > 100 ? curso.Descripcion.Substring(0, 100) + "..." : curso.Descripcion,
                    AutoSize = false,
                    Location = new Point(10, 30),
                    Size = new Size(280, 55),
                    Font = new Font("Segoe UI", 9)
                };

                Button btnEliminar = new Button
                {
                    Text = "Eliminar",
                    Location = new Point(10, 110),
                    Width = 80,
                    Height = 25
                };

                btnEliminar.Click += (sender, e) =>
                {
                    var confirmar = MessageBox.Show("¿Estás seguro de eliminar este curso?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirmar == DialogResult.Yes)
                    {
                        if (TablaCurso.EliminarCurso(curso.Id))
                        {
                            MessageBox.Show("Curso eliminado correctamente.");
                            CargarCursos();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el curso.");
                        }
                    }
                };

                Button btnVerArchivo = new Button();
                btnVerArchivo.Text = "Ver archivo";
                btnVerArchivo.Location = new Point(10, 85);
                btnVerArchivo.Click += (s, e) =>
                {
                    string carpetaArchivos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos");
                    string rutaCompleta = Path.Combine(carpetaArchivos, curso.RutaArchivo);
                    MessageBox.Show("ID del profesor: " + rutaCompleta);

                    if (File.Exists(rutaCompleta))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = rutaCompleta,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("Archivo no encontrado: " + rutaCompleta);
                    }
                };

                Label lblFecha = new Label
                {
                    Text = "Publicado el: " + curso.FechaPublicacion.ToShortDateString(),
                    Location = new Point(20, 90),
                    AutoSize = true
                };

                panelCurso.Controls.Add(lblTitulo);
                panelCurso.Controls.Add(lblDescripcion);
                panelCurso.Controls.Add(btnEliminar);
                panelCurso.Controls.Add(btnVerArchivo);
                panelCurso.Controls.Add(lblFecha);

                pnlCursos.Controls.Add(panelCurso);
            }
        }


        private void crearCursoClick(object sender, EventArgs e)
        {
            CrearCursoForm crearCurso = new CrearCursoForm(profesorId);
            crearCurso.FormClosed += (s, args) => CargarCursos();
            crearCurso.ShowDialog();
        }

        private void SalirClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Learnify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
        
        private void CerrarSesion(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Learnify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnServidorNetworking_click(object sender, EventArgs e)
        {
            ServidorForm servidor = new ServidorForm();
            servidor.Show();
        }
    }
}
