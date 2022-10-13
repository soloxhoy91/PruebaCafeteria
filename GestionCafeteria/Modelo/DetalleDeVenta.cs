using GestionCafeteria.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class DetalleDeVenta
    {
        public void DetalleDeventa()
        {
            this.idProducto = 0;
            this.idDetalleVenta = 0;
            this.idVenta = 0;
            this.cantidad = 0;
            
        }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public decimal importeTotal()
        {
            return cantidad * this.getPrecioProducto();
        }

        public String getNombreProducto()
        {
            return GestorProductos.ObtenerProducto(this.idProducto).Nombre;
        }

        public Decimal getPrecioProducto()
        {
            return GestorProductos.ObtenerProducto(this.idProducto).PrecioUnitario;
        }




    }
}
