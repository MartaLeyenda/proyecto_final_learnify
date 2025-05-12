using proyecto_final_learnify.BaseDeDatos;
using proyecto_final_learnify.Páginas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_learnify
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm();
            registro.ShowDialog();
        }

        private void cerrarApp(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Learnify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void InicioSesionClick(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == ""|| txtContrasenna.Text.Trim() == "")
            {
                MessageBox.Show("No puede haber ningún campo vacío");
                return;
            }

            Usuario usuario = TablaUsurios.ObtenerUsuarioPorCredenciales(txtUsuario.Text, txtContrasenna.Text);

            if (usuario != null)
            {
                MessageBox.Show("¡Bienvenid@, " + usuario.Nombre + "!", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Comparativa del tipo de usuario y abrir la sesión de profesor o alumno
                if (usuario.Tipo == Usuario.TipoUsuario.profesor)
                {
                    VistaProfesorForm formProfesor = new VistaProfesorForm(usuario.Id);
                    formProfesor.ShowDialog();
                } else
                {
                    Formularios.VerCursosForm formAlumno = new Formularios.VerCursosForm(usuario.Id);
                    formAlumno.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("La contraseña o el nombre de usuario son incorrectos");
                return;
            }
        }
    }
}
