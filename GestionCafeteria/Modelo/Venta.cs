using GestionCafeteria.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class Venta
    {
        //static List<DetalleDeVenta> detalleDeVentas = new List<DetalleDeVenta>();
        private static GestorDB gs = new GestorDB();

        public Venta()
        {
            this.IdVendedor = 0;
            this.ventaDate = new DateTime();
            this.IdMetodoPago = 0;
            if (gs == null)
            {
                gs = new GestorDB();
            }

        }

        public int IdVenta { get; set; }
        public int IdVendedor { get; set; }
        public DateTime ventaDate { get; set; }
        public Vendedor Vendedor() {return GestorVendedor.ObtenerVendedor(this.IdVendedor); }

        public int IdMetodoPago { get; set; }

        //public List<DetalleDeVenta> DetalleDeVentas()
        //{
        //    return Obtener
        //}



        

    }
}
