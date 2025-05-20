using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyecto_final_learnify.Usuario;

namespace proyecto_final_learnify
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtApellidos.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || txtGmail.Text.Trim() == "" || txtContrasenna.Text.Trim() == "" || txtContrasenna2.Text.Trim() == "" || numEdad.Value <= 0)
            {
                MessageBox.Show("Alguno de los datos está vacío o la edad no es válida", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtGmail.Text.Trim().EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El correo debe terminar en '@gmail.com'", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario.TipoUsuario tipo = cbTipo.SelectedItem.ToString() == "profesor" ? Usuario.TipoUsuario.profesor : Usuario.TipoUsuario.alumno;

            if (txtContrasenna.Text.Equals(txtContrasenna2.Text))
            {
                Usuario registrarUsuario = new Usuario(txtNombre.Text, txtApellidos.Text, (int)numEdad.Value, txtUsuario.Text, txtGmail.Text, txtContrasenna.Text, calendarioFecha.Value, tipo);
                if (MessageBox.Show($"¿Sus datos están correctos?\r\n{txtNombre.Text} {txtApellidos.Text}\r\n{(int)numEdad.Value} años\r\nNombre de usuario: {txtUsuario.Text}\r\nGmail: {txtGmail.Text}", "CONFIRMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (BaseDeDatos.TablaUsurios.añadirUsuario(registrarUsuario))
                    {
                        MessageBox.Show("¡Usuario registrado correctamente!");
                        this.Close();
                    } else
                    {
                        MessageBox.Show("El gmail o el nombre de usuario ya existen", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            } else
            {
                MessageBox.Show("Las contraseñas deben coincidir", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
