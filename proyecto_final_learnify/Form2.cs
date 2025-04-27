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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtApellidos.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || txtGmail.Text.Trim() == "" || txtContrasenna.Text.Trim() == "" || txtContrasenna2.Text.Trim() == "" || numEdad.Value <= 0)
            {
                MessageBox.Show("Alguno de los datos está vacío o la edad es incorrecta", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                // Guardar datos en la base de datos
            }
        }
    }
}
