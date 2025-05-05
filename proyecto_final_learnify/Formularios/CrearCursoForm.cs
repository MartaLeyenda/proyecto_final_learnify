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
    public partial class CrearCursoForm : Form
    {
        public CrearCursoForm()
        {
            InitializeComponent();
        }

        private void cargarArchivo(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Todos los archivos|*.*|PDF|*.pdf|Videos|*.mp4;*.avi;*.mov";
                dialog.Title = "Seleccionar archivo del curso";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtArchivo.Text = dialog.FileName;
                }
            }
        }

        private void crearCurso(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || txtArchivo.Text.Trim() == "")
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos");
            Directory.CreateDirectory(carpetaDestino);
            string rutaDestino = Path.Combine(carpetaDestino, Path.GetFileName(txtArchivo.Text));
            File.Copy(txtArchivo.Text, rutaDestino, true);

            MessageBox.Show("Curso creado con éxito.");
            this.Close();
        }
    }
}
