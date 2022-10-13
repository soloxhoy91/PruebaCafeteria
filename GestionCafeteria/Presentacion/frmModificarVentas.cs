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
    public partial class frmModificarVentas : Form
    {
        private int idVenta = 0;
        public frmModificarVentas(int idVenta)
        {
            this.idVenta = idVenta;
            InitializeComponent();
        }

        private void frmModificarVentas_Load(object sender, EventArgs e)
        {
            cbxVendedor.Enabled = false;


            foreach (Modelo.Vendedor item in GestorVendedor.ObtenerVendedores())
            {
                cbxVendedor.Items.Add(item.Nombre);
            }

            CargarVenta();
        }



        private void CargarVenta()
        {
            if (idVenta != 0)
            {
                Venta aux = GestorVentas.ObtenerVenta(idVenta);
                List<DetalleDeVenta> listaDetalle = GestorDetalleVenta.ObtenerDetalles();
                Decimal importeTotal = 0;


                if (aux.IdVenta == idVenta)
                {
                    for (int i = 0; i < cbxVendedor.Items.Count; i++)
                    {
                        if (cbxVendedor.Items[i].ToString() == aux.Vendedor().Nombre)
                        {
                            cbxVendedor.SelectedIndex = i;
                        }
                    }

                    for (int i = 0; i < listaDetalle.Count; i++)
                    {

                        if (listaDetalle[i].idVenta == idVenta)
                        {
                            dgvDetalleVenta.Rows.Add(listaDetalle[i].idProducto,
                                listaDetalle[i].getNombreProducto(),
                                listaDetalle[i].cantidad,
                                listaDetalle[i].getPrecioProducto(),
                                listaDetalle[i].importeTotal());
                            importeTotal+=listaDetalle[i].importeTotal();
                        }
                    }

                    lblTotalFinal.Text = importeTotal.ToString();
                    cbxVendedor.Enabled = true;


                }
                else
                {
                    MessageBox.Show("No se encontro una venta registrada con el codigo, ingrese uno nuevo.");
                    LimpiarConsulta();
                }
            }
        }
        private void LimpiarConsulta()
        {
            lblTotalFinal.Text = "";
            cbxVendedor.SelectedIndex = 0;
            cbxVendedor.Enabled = false;
        }




        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


    }
}
