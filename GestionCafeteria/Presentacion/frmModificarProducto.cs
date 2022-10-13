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
    public partial class frmModificarProducto : Form
    {
        private int IdProducto { get; set; }
        public frmModificarProducto(int idProducto)
        {
            InitializeComponent();
            this.IdProducto = idProducto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModificarProducto_Load(object sender, EventArgs e)
        {
            var prod = Negocio.GestorProductos.ObtenerProducto(this.IdProducto);
            lblCodigo.Text = prod.IdProducto.ToString();
            txtNombre.Text = prod.Nombre;
            txtPrecio.Text = prod.PrecioUnitario.ToString();
            chkActivo.Checked = prod.Activo;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modelo.Producto producto = new Modelo.Producto();
            producto.IdProducto = this.IdProducto;
            producto.Nombre = txtNombre.Text;
            producto.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
            producto.Activo = chkActivo.Checked;
            string ret = Negocio.GestorProductos.ActualizarProducto(producto);
            MessageBox.Show(ret);
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            string ret = Negocio.GestorProductos.EliminarProducto(this.IdProducto);
            MessageBox.Show(ret);
            this.Close();
        }
    }
}
