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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cmbCampo.SelectedIndex = 0;
            cmbOrden.SelectedIndex = 0;
            ListarProductos();
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value);
            int aux = GestorProductos.ObtenerProducto(idProducto).IdProducto;
            if (idProducto == aux)
            {
                frmModificarProducto ventana = new frmModificarProducto(idProducto);
                ventana.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se puede encontrar el recurso en la base de datos.");
            }
            ListarProductos();

        }
        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProductos();
        }
        private void txtFilNombre_TextChanged(object sender, EventArgs e)
        {
            ListarProductos();
        }
        private void ListarProductos()
        {
            var lista = GestorProductos.ObtenerProductos();

            lista = chkSoloActivos.Checked ? lista.Where(x => x.Activo == true).ToList() : lista;
            lista = txtFilNombre.Text != "" ? lista.Where(x => x.Nombre.ToUpper().Contains(txtFilNombre.Text.ToUpper())).ToList() : lista;


            if (cmbCampo.Text != "")
            {
                switch (cmbCampo.SelectedIndex)
                {
                    case 0:
                        lista = cmbOrden.SelectedIndex == 0 ? lista.OrderBy(x => x.IdProducto).ToList() : lista.OrderByDescending(x => x.IdProducto).ToList();
                        break;
                    case 1:
                        lista = cmbOrden.SelectedIndex == 0 ? lista.OrderBy(x => x.Nombre).ToList() : lista.OrderByDescending(x => x.Nombre).ToList();
                        break;
                    case 2:
                        lista = cmbOrden.SelectedIndex == 0 ? lista.OrderBy(x => x.PrecioUnitario).ToList() : lista.OrderByDescending(x => x.PrecioUnitario).ToList();
                        break;

                }
            }
            dgvProductos.Rows.Clear();
            foreach (Modelo.Producto item in lista)
            {

                dgvProductos.Rows.Add(item.IdProducto,
                    item.Nombre,
                    item.PrecioUnitario,

                    item.Activo,
                    "");




            }


        }

        

        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarProductos();
        }
    }
}
