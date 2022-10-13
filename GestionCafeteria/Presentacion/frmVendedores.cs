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
    public partial class frmVendedores : Form
    {
        public frmVendedores()
        {
            InitializeComponent();
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            ListarVendedores();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarVendedor venta = new frmAgregarVendedor();
            venta.ShowDialog();
            ListarVendedores();
            
        }

        private void ListarVendedores()
        {
            var lista = GestorVendedor.ObtenerVendedores();

            lista = txtNombre.Text != "" || txtIdVendedor.Text != "" ? lista.Where(x =>
            x.IdVendedor.ToString().Contains(txtIdVendedor.Text) &&
            x.Nombre.Contains(txtNombre.Text)).ToList() : lista;


            dgvVendedores.Rows.Clear();
            foreach (Modelo.Vendedor item in lista)
            {
                dgvVendedores.Rows.Add(item.IdVendedor,
                                        item.Nombre,
                                        item.Activo);
            }

        }

        private void dgvVendedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ListarVendedores();
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
