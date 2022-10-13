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
    public partial class frmListaVentas : Form
    {
        private List<Venta> listaVentas = new List<Venta>();
        private List<DetalleDeVenta>listaDetalleVenta= new List<DetalleDeVenta>();
        public frmListaVentas()
        {
            InitializeComponent();
        }

        private void frmModificarVentas_Load(object sender, EventArgs e)
        {
            ListarVentas();
        }

        private void ListarVentas()
        {

            listaVentas = GestorVentas.ObtenerVentas();
            DateTime desde = Convert.ToDateTime(dtpDesde.Value.Day + "/" + dtpDesde.Value.Month + "/" + dtpDesde.Value.Year);
            DateTime hasta = dtpHasta.Value.AddDays(1);

            listaVentas = listaVentas.Where(x => x.ventaDate >= desde && x.ventaDate <= hasta).ToList();

            if (txtFiltrar.Text != "")
            {
                switch (cbxFiltro.SelectedIndex)
                {
                    case 0:
                        listaVentas = listaVentas.Where(x => x.IdVenta == Convert.ToInt32(txtFiltrar.Text)).ToList();
                        break;

                    case 1:
                        listaVentas = listaVentas.Where(x => x.Vendedor().Nombre == txtFiltrar.Text).ToList();
                        break;

                }
            }

            dgvVentas.Rows.Clear();
            Decimal total = 0;
            foreach (Modelo.Venta item in listaVentas)
            {
                dgvVentas.Rows.Add(item.IdVenta,
                                        item.Vendedor().Nombre,
                                        listaDetalleVenta.Where(x=>x.idVenta==item.IdVenta).First().importeTotal(),
                                        item.ventaDate);


                total += listaDetalleVenta.Where(x => x.idVenta == item.IdVenta).First().importeTotal();
            }
            lblTotalFinal.Text = total.ToString();




        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmModificarVentas Ventana = new frmModificarVentas();
            //Ventana.ShowDialog();
            //Ventana.ShowDialog();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            ListarVentas();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            ListarVentas();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            ListarVentas();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = listaVentas[e.RowIndex].IdVenta;
            frmModificarVentas Ventana =new frmModificarVentas(codigo);
            Ventana.ShowDialog();
        }
    }
}
