using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Negocio
{
    internal class GestorDetalleVenta
    {
        private static GestorDB gs = new GestorDB();
        public List<DetalleDeVenta> detalleDeVentas = new List<DetalleDeVenta>();

        public GestorDetalleVenta()
        {
            if (gs == null)
            {
                gs = new GestorDB();
            }
        }

        public void InsertarDetalles(List<DetalleDeVenta> lista)
        {

            for (int i = 0; i < lista.Count; i++)
            {
                try
                {
                    string query = "INSERT INTO DetalleDeVenta (IdProducto, IdVenta, Cantidad) VALUES (" + lista[i].idProducto + ", "
                                                                         + lista[i].idVenta + ", "
                                                                         + lista[i].cantidad + ")";
                    gs.QueryNonQuery(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }
        public static DetalleDeVenta ObtenerDetalle(int idVenta)
        {

            string query = "select * from DetalleDeVenta";
            DataTable dt = gs.QueryReader(query);
            List<DetalleDeVenta> lista = new List<DetalleDeVenta>();
            DetalleDeVenta detalleVenta = new DetalleDeVenta();


            foreach (DataRow item in dt.Rows)
            {
                if (idVenta == Convert.ToInt32(item["IdVenta"].ToString()))
                {
                    detalleVenta.idDetalleVenta = Convert.ToInt32(item["IdDetalleVenta"].ToString());
                    detalleVenta.idProducto = Convert.ToInt32(item["IdProducto"].ToString());
                    detalleVenta.idVenta = Convert.ToInt32(item["IdVenta"].ToString());
                    detalleVenta.cantidad = Convert.ToInt32(item["Cantidad"].ToString());
                }

            }
            return detalleVenta;
        }
        public static List<DetalleDeVenta> ObtenerDetalles()
        {
            string query = "select * from DetalleDeVenta";
            DataTable dt = gs.QueryReader(query);
            List<DetalleDeVenta> lista = new List<DetalleDeVenta>();

            foreach (DataRow item in dt.Rows)
            {
                DetalleDeVenta detalleVenta = new DetalleDeVenta();
                detalleVenta.idDetalleVenta = Convert.ToInt32(item["IdDetalleVenta"].ToString());
                detalleVenta.idProducto = Convert.ToInt32(item["IdProducto"].ToString());
                detalleVenta.idVenta = Convert.ToInt32(item["IdVenta"].ToString());
                detalleVenta.cantidad = Convert.ToInt32(item["Cantidad"].ToString());
                lista.Add(detalleVenta);
            }
            return lista;

        }
        public string InsertarDetalle(DetalleDeVenta nuevo)
        {
            string ret = "";
            if (!ExistDetalle(nuevo.idDetalleVenta))
            {
                try
                {
                    string query = "INSERT INTO DetalleDeVenta VALUES (" + nuevo.idDetalleVenta + ", "
                                                                         + nuevo.idProducto + ", "
                                                                         + nuevo.idVenta + ", "
                                                                         + nuevo.cantidad + ")";
                    gs.QueryNonQuery(query);

                    ret = "Detalle registrado con exito.";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;

                }
            }
            else
            {
                ret = "El detalle con el codigo " + nuevo.idDetalleVenta + " ya existe";
            }
            return ret;
        }

        public string ActualizarDetalle(DetalleDeVenta actualizar)
        {
            if (ExistDetalle(actualizar.idDetalleVenta))
            {
                try
                {

                    string query = "UPDATE DetalleDeVenta SET IdProducto= " + actualizar.idProducto +
                                                   " IdVenta= " + actualizar.idVenta +
                                                   " Cantidad= " + actualizar.cantidad +
                                                   "WHERE IdDetalleVenta= " + actualizar.idDetalleVenta + ")";
                    gs.QueryNonQuery(query);


                    return "Detalle actualizado con exito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }

            }
            else
            {
                return "No se encontro Detalle registrado con el codigo " + actualizar.idDetalleVenta + " para ser actualizado.";
            }
        }
        public string EliminarDetalle(int idCodigo)
        {
            if (ExistDetalle(idCodigo))
            {

                try
                {
                    string query = "DELETE FROM DetalleDeVenta WHERE IdDetalleVenta= " + idCodigo;
                    gs.QueryReader(query);

                    return "Elemento eliminado con exito.";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else
            {
                return "No existe elemento registrado con el codigo " + idCodigo + " para ser eliminado.";
            }

        }

        public Decimal ImporteTotalVenta()
        {
            decimal total = 0;
            detalleDeVentas = ObtenerDetalles();
            for (int i = 0; i < detalleDeVentas.Count; i++)
            {
                total += detalleDeVentas[i].importeTotal();
            }

            return total;
        }
        public decimal RecargoVenta(int IdMetodoPago)
        {
            decimal recargo = 0;
            //aca deberia busca en el gestor de metodo de pago el importe del recargo segun el id
            return (this.ImporteTotalVenta() * recargo) / 100;

        }
        private bool ExistDetalle(int idDetalle)
        {
            detalleDeVentas = ObtenerDetalles();
            return this.detalleDeVentas.Count(x => x.idDetalleVenta == idDetalle) > 0 ? true : false;
        }
    }
}
