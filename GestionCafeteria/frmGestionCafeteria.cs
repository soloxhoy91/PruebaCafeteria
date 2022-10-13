using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionCafeteria.Presentacion;

namespace GestionCafeteria
{
    public partial class frmGestionCafeteria : Form
    {
        public frmGestionCafeteria()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoProducto ventana = new frmNuevoProducto();
            ventana.ShowDialog();
        }

        private void listadoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos ventana = new frmProductos();
            ventana.ShowDialog();
        }

        private void frmGestionCafeteria_Load(object sender, EventArgs e)
        {
            //DatosGlobales.CargarProductosEjemplo();
            Negocio.GestorProductos.CargarProductosDePrueba();

            Negocio.GestorProductos.ObtenerProducto(1);
            var lista =Negocio.GestorProductos.ObtenerProductos();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();// +" "+ DateTime.Now.ToShortTimeString();
        }

        private void registrarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaNueva ventana = new frmVentaNueva();
            ventana.ShowDialog();
        }

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaVentas ventana = new frmListaVentas();
            ventana.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmModificarProducto ventana = new frmModificarProducto(0);
            ventana.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.frmProductos frmProducto = new Presentacion.frmProductos();
            frmProducto.ShowDialog();
        }

        private void vendedoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendedores ventana = new frmVendedores();
            ventana.ShowDialog();
        }
    }
}
