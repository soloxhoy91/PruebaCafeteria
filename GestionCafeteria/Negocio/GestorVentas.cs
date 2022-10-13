using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestionCafeteria.Negocio
{
    internal class GestorVentas
    {
        private static GestorDB gs = new GestorDB();
        static List<Venta> listaVentas = new List<Venta>();



        public static String InsertarVenta(Venta nuevo)
        {
            string ret = "";
            if (!ExisteVenta(nuevo.IdVenta))
            {
                try
                {
                    string query = "INSERT INTO Venta (IdMetodoPago, IdVendedor, VentaDate) VALUES ( "+nuevo.IdMetodoPago+", "+nuevo.IdVendedor+ ", Format('" + nuevo.ventaDate + "','dd-mm-yyyy hh:mm:ss'))";
                    gs.QueryNonQuery(query);
                    ret = "Venta registrada con exito.";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;

                }
            }
            else
            {
                ret = "La venta con le codigo " + nuevo.IdVenta + " ya existe";
            }
            return ret;

        }

        public static string ActualizarVenta(Venta actualizar)
        {
            if (ExisteVenta(actualizar.IdVenta))
            {
                try
                {
                    
                    string query = "UPDATE Venta SET IdMetodoPago= "+actualizar.IdMetodoPago+
                                                   ", IdVendedor= "+actualizar.IdVendedor+
                                                   ", VentaDate= "+actualizar.ventaDate+
                                                   "WHERE IdVenta= "+actualizar.IdVenta+")";
                    gs.QueryNonQuery(query);


                    return "Producto actualizado con exito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }
                
            }
            else
            {
                return "No se encontro venta registrada con el codigo " + actualizar.IdVenta + " para ser actualizado.";
            }
        }
        public static string EliminarVenta(int idCodigo)
        {
            if (ExisteVenta(idCodigo))
            {
                string query="DELETE FROM Venta WHERE IdVenta= "+idCodigo;
                gs.QueryNonQuery(query);

                return "Elemento eliminado con exito.";
                
            }
            else
            {
                return "No existe elemento registrado con el codigo " + idCodigo + " para ser eliminado.";
            }


        }

        public static List<Venta> ObtenerVentas()
        {
            string query = "select * from Venta ";
            DataTable dt = gs.QueryReader(query);
            listaVentas = new List<Venta>();
            foreach (DataRow item in dt.Rows)
            {
                Venta aux = new Venta();
                aux.IdVenta = Convert.ToInt32(item["IdVenta"].ToString());
                aux.IdMetodoPago = Convert.ToInt32(item["IdMetodoPago"].ToString());
                aux.IdVendedor = Convert.ToInt32(item["IdVendedor"].ToString());
                aux.ventaDate = Convert.ToDateTime(item["VentaDate"].ToString());

                listaVentas.Add(aux);
            }
            return listaVentas;
        }

        public static Venta ObtenerVenta(int idVenta)
        {

            string query = "select * from Venta WHERE IdVenta= "+idVenta;
            DataTable dt = gs.QueryReader(query);
            Venta aux = new Venta();

            foreach (DataRow item in dt.Rows)
            {
                if (idVenta == Convert.ToInt32(item["IdVenta"].ToString()))
                {
                    aux.IdVenta = Convert.ToInt32(item["IdVenta"].ToString());
                    aux.IdMetodoPago = Convert.ToInt32(item["IdMetodoPago"].ToString());
                    aux.IdVendedor = Convert.ToInt32(item["IdVendedor"].ToString());
                    aux.ventaDate = Convert.ToDateTime(item["VentaDate"].ToString());
                }

            }
            return aux;
        }

        public static Boolean ExisteVenta(int idVentas)
        {
            listaVentas = ObtenerVentas();
            return listaVentas.Count(x => x.IdVenta == idVentas) > 0 ? true : false;
        }

    }
}
