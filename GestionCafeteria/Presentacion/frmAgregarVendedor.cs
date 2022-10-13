using GestionCafeteria.Modelo;
using GestionCafeteria.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCafeteria.Presentacion
{
    public partial class frmAgregarVendedor : Form
    {
        public frmAgregarVendedor()
        {
            InitializeComponent();


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Vendedor aux = new Vendedor();

            aux.IdVendedor = Convert.ToInt32(txtIdVendedor.Text);
            aux.Nombre = txtNombre.Text;

            MessageBox.Show(GestorVendedor.InsertarVendedor(aux));

            limpiarCampos();
        }

        private void frmAgregarVendedor_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "" && txtNombre.Text != "")
            {
                btnAgregar.Enabled = true;

            }
            else btnAgregar.Enabled = false;

        }

        private void txtIdVendedor_TextChanged(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "" && txtNombre.Text != "")
            {
                btnAgregar.Enabled = true;

            }
            else btnAgregar.Enabled = false;
        }

        private void limpiarCampos()
        {
            txtIdVendedor.Text = "";
            txtNombre.Text = "";
        }

        private void txtIdVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
