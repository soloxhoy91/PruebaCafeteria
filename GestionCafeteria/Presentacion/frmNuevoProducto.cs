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
    public partial class frmNuevoProducto : Form
    {
        public frmNuevoProducto()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Modelo.Producto producto= new Modelo.Producto();
            try
            {
                producto.IdProducto=Convert.ToInt32(txtCodigo.Text);
                producto.Nombre = txtNombre.Text;
                producto.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                producto.Activo=chkActivo.Checked;
                string ret=Negocio.GestorProductos.InsertarProducto(producto);
                MessageBox.Show(ret);
                if (ret.Contains("exito"))
                {
                    LimparCampos();
                }
                else
                {
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
