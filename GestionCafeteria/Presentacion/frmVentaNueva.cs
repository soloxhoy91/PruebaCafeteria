using GestionCafeteria.Negocio;
using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace GestionCafeteria.Presentacion
{
    public partial class frmVentaNueva : Form
    {
        static List<DetalleDeVenta> detalleDeVentas = new List<DetalleDeVenta>();

        public frmVentaNueva()
        {
            InitializeComponent();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Venta auxVenta = new Venta();

            int IdVenta = Convert.ToInt32(tbxCodVenta.Text);
            String nomVendedor = cbxVendedor.Text;

            auxVenta.IdVenta = IdVenta;
            auxVenta.IdVendedor = GestorVendedor.ObtenerVendedores().Where(x => x.Nombre == nomVendedor).First().IdVendedor;
            auxVenta.ventaDate = DateTime.Now;
            auxVenta.IdMetodoPago = cbxMetodoPago.SelectedIndex;
            GestorDetalleVenta.InsertarDetalles(detalleDeVentas);


            MessageBox.Show(GestorVentas.InsertarVenta(auxVenta));

            limpiarCampos();

        }

        //private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (cbxProducto.SelectedItem.ToString() != "" && tbxCantidad.Text != "")
        //    {
        //        List<Producto> auxList = GestorProductos.ObtenerProductos();
        //        Decimal precio = GestorProductos.ObtenerProductos().Where(x => x.Nombre == cbxProducto.SelectedItem.ToString()).First().PrecioUnitario;
        //        lblSubTotal.Text = Convert.ToString(precio * Convert.ToInt32(tbxCantidad.Text));
        //    }
        //    else
        //    {
        //        lblSubTotal.Text = "";
        //    }
        //}

        private void frmVentaNueva_Load(object sender, EventArgs e)
        {

            List<Producto> auxProducto = GestorProductos.ObtenerProductos();
            List<Vendedor> auxVendedor = GestorVendedor.ObtenerVendedores();
            List<MetodoPago> auxMetodo = GestorMetodoPago.ObtenerMetodosPagos();

            for (int i = 0; i < auxProducto.Count; i++)
            {
                cbxProducto.Items.Add(auxProducto[i].Nombre);
            }

            for (int i = 0; i < auxVendedor.Count; i++)
            {
                cbxVendedor.Items.Add(auxVendedor[i].Nombre);
            }

            for (int i = 0; i < auxMetodo.Count; i++)
            {
                cbxMetodoPago.Items.Add(auxMetodo[i].Nombre);
            }

        }



        private void tbxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem.ToString() != "" && tbxCantidad.Text != "")
            {
                List<Producto> auxList = GestorProductos.ObtenerProductos();
                Decimal precio = GestorProductos.ObtenerProductos().Where(x => x.Nombre == cbxProducto.SelectedItem.ToString()).First().PrecioUnitario;
                lblSubTotal.Text = Convert.ToString(precio * Convert.ToInt32(tbxCantidad.Text));
            }
            else
            {
                lblSubTotal.Text = "";
            }
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbxCodVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void limpiarCampos()
        {
            tbxCantidad.Text = "";
            tbxCodVenta.Text = "";
            cbxProducto.SelectedIndex = 0;
            cbxVendedor.SelectedIndex = 0;
            dgvDetalleVentas.Rows.Clear();
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            DetalleDeVenta auxDetalle = new DetalleDeVenta();
            //auxDetalle.idVenta = Convert.ToInt32(tbxCodVenta.Text);
            auxDetalle.cantidad = Convert.ToInt32(tbxCantidad.Text);
            auxDetalle.idProducto = Convert.ToInt32(GestorProductos.ObtenerProductos().Where(x => x.Nombre == cbxProducto.SelectedItem.ToString()).First().IdProducto);

            detalleDeVentas.Add(auxDetalle);

            dgvDetalleVentas.Rows.Add(auxDetalle.idProducto,
                                        GestorProductos.ObtenerProducto(auxDetalle.idProducto).Nombre,
                                        GestorProductos.ObtenerProducto(auxDetalle.idProducto).PrecioUnitario,
                                        auxDetalle.cantidad,
                                        auxDetalle.importeTotal());


        }

        private void cbxMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
