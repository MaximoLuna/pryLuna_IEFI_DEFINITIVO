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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string pais = cmbPais.SelectedItem.ToString();
            int edad = Convert.ToInt32(nudEdad.Value);
            bool esMasculino = optMasculino.Checked;
            decimal importe = nudIngreso.Value;
            int puntaje = Convert.ToInt32(nudPuntaje.Value);

            ClsConectarBD objConn = new ClsConectarBD();
            objConn.agregarSocio(nombre, apellido, pais, edad, esMasculino, importe, puntaje);

            MessageBox.Show("Socio agregado con éxito.");

            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbPais.SelectedIndex = -1;
            nudEdad.Value = 50;
            optFemenino.Checked = false;
            optMasculino.Checked = false;
            nudIngreso.Value = 1000;
            nudPuntaje.Value = 129.5m;
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
