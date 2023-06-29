using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;

namespace pryLuna_IEFI_LB2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            ClsConectarBD objConn = new ClsConectarBD();
            objConn.cargarCombo(cmbPais);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text != "")
            {
                cmbPais.Enabled = true;
            }
            else
            {
                cmbPais.Enabled = false;
            }
        }

        private void nudEdad_ValueChanged(object sender, EventArgs e)
        {
            if (nudEdad.Value != 0)
            {
                mrcSexo.Enabled = true;
            }
            else
            {
                mrcSexo.Enabled = false;
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex != -1)
            {
                nudEdad.Enabled = true;
            }
            else
            {
                nudEdad.Enabled = false;
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            if (nudIngreso.Text != "")
            {
                nudPuntaje.Enabled = true;
            }
            else
            {
                nudPuntaje.Enabled = false;
            }
        }

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {
            if (nudPuntaje.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void mrcRegistroPais_Enter(object sender, EventArgs e)
        {

        }

        private void optMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (optMasculino.Checked == true)
            {
                nudIngreso.Enabled = true;
            }
            else
            {
                nudIngreso.Enabled = false;
            }
        }

        private void optFemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (optFemenino.Checked == true)
            {
                nudIngreso.Enabled = true;
            }
            else
            {
                nudIngreso.Enabled = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es una letra ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es una letra ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtPuntaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento
                e.Handled = true;
            }
        }

        private void txtApellido_TextChanged_1(object sender, EventArgs e)
        {
            if (txtApellido.Text != "")
            {
                cmbPais.Enabled = true;
            }
            else
            {
                cmbPais.Enabled = false;
            }
        }

        private void txtNombre_TextChanged_1(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        private void nudEdad_ValueChanged_1(object sender, EventArgs e)
        {
            if (nudEdad.Value != 0)
            {
                mrcSexo.Enabled = true;
            }
            else
            {
                mrcSexo.Enabled = false;
            }
        }

        private void cmbPaises_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex != -1)
            {
                nudEdad.Enabled = true;
            }
            else
            {
                nudEdad.Enabled = false;
            }
        }

        private void txtImporte_TextChanged_1(object sender, EventArgs e)
        {
            if (nudIngreso.Text != "")
            {
                nudPuntaje.Enabled = true;
            }
            else
            {
                nudPuntaje.Enabled = false;
            }
        }

        private void txtPuntaje_TextChanged_1(object sender, EventArgs e)
        {
            if (nudPuntaje.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void optMasc_CheckedChanged_1(object sender, EventArgs e)
        {
            if (optMasculino.Checked == true)
            {
                nudIngreso.Enabled = true;
            }
            else
            {
                nudIngreso.Enabled = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //declaracion de variables
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string pais = cmbPais.SelectedItem.ToString();
            int edad = (int)nudEdad.Value;
            bool esMasculino = optMasculino.Checked;
            decimal importe = decimal.Parse(nudIngreso.Text);
            int puntaje = Convert.ToInt32(nudPuntaje.Value);



            //instancia de objeto
            ClsConectarBD objConn = new ClsConectarBD();
            objConn.agregarSocio(nombre, apellido, pais, edad, esMasculino, importe, puntaje);

            MessageBox.Show("Socio agregado con éxito.");

            // Limpiar los campos después de agregar un socio
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbPais.SelectedIndex = -1;
            nudEdad.Value = 50;
            optFemenino.Checked = false;
            optMasculino.Checked = false;
            nudIngreso.Value = 1000;
            nudPuntaje.Value = 129.5m;
        }

        private void nudIngreso_ValueChanged(object sender, EventArgs e)
        {
            if (nudIngreso.Text != "")
            {
                nudPuntaje.Enabled = true;
            }
            else
            {
                nudPuntaje.Enabled = false;
            }
        }

        private void nudPuntaje_ValueChanged(object sender, EventArgs e)
        {
            if (nudPuntaje.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void btnRegistrarPais_Click(object sender, EventArgs e)
        {
            if (txtNombrePais.Text == "")
            {
                MessageBox.Show("Ingrese un campo");
                return;
            }
            else
            {
                ClsConectarBD objConn = new ClsConectarBD();
                objConn.cargarPais(txtNombrePais.Text);
                objConn.cargarCombo(cmbPais);
            }
            txtNombrePais.Text = "";
        }
    }
}
