using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Negocio
{
    internal class GestorMetodoPago
    {
        private static GestorDB gs = new GestorDB();
        static List<MetodoPago> listaMetodoPago = new List<MetodoPago>();

        public static String InsertarMetodo(MetodoPago nuevo)
        {
            string ret = "";
            if (!ExisteMetodoPago(nuevo.IdMetodoPago))
            {
                try
                {
                    string query = "INSERT INTO MetodoPago VALUES (" + nuevo.IdMetodoPago + ", '" 
                                                                     + nuevo.Nombre + "'," 
                                                                     + nuevo.Recargo + "," 
                                                                     + "True)";
                    gs.QueryReader(query);
                    ret = "Metodo de pago registrado con exito.";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;

                }
            }
            else
            {
                ret = "El metodo de pago con le codigo " + nuevo.IdMetodoPago + " ya existe";
            }
            return ret;

        }

        public static string ActualizarMetodoPago(MetodoPago actualizar)
        {
            if (ExisteMetodoPago(actualizar.IdMetodoPago))
            {
                try
                {

                    string query = "UPDATE MetodoPago SET Nombre= '" + actualizar.Nombre +
                                                   "', Recargo= " + actualizar.Recargo +
                                                   ", Activo= " + actualizar.Activo +
                                                   "WHERE IdMetodoPago= " + actualizar.IdMetodoPago + ")";
                    gs.QueryReader(query);


                    return "Metodo de pago actualizado con exito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }

            }
            else
            {
                return "No se encontro metodo de pago registrado con el codigo " + actualizar.IdMetodoPago + " para ser actualizado.";
            }
        }
        public static string EliminarMetodo(int idCodigo)
        {
            if (ExisteMetodoPago(idCodigo))
            {
                string query = "DELETE FROM MetodoPago WHERE IdMetodoPago= " + idCodigo;
                gs.QueryReader(query);

                return "Elemento eliminado con exito.";

            }
            else
            {
                return "No existe elemento registrado con el codigo " + idCodigo + " para ser eliminado.";
            }


        }

        public static List<MetodoPago> ObtenerMetodosPagos()
        {
            string query = "select * from MetodoPago ";
            DataTable dt = gs.QueryReader(query);
            listaMetodoPago = new List<MetodoPago>();
            foreach (DataRow item in dt.Rows)
            {
                MetodoPago aux = new MetodoPago();
                aux.IdMetodoPago = Convert.ToInt32(item["IdMetodoPago"].ToString());
                aux.Nombre = item["Nombre"].ToString();
                aux.Recargo = Convert.ToInt32(item["Recargo"].ToString());
                aux.Activo = Convert.ToBoolean(item["Activo"].ToString());
                
                listaMetodoPago.Add(aux);
            }
            return listaMetodoPago;
        }

        public static MetodoPago ObtenerMetododepago(int idMetodoPago)
        {

            string query = "select * from MetodoPago WHERE IdMetodoPago= " + idMetodoPago;
            DataTable dt = gs.QueryReader(query);
            MetodoPago aux = new MetodoPago();

            foreach (DataRow item in dt.Rows)
            {
                aux.IdMetodoPago = Convert.ToInt32(item["IdMetodoPago"].ToString());
                aux.Nombre = item["Nombre"].ToString();
                aux.Recargo = Convert.ToInt32(item["Recargo"].ToString());
                aux.Activo = Convert.ToBoolean(item["Activo"].ToString());

            }
            return aux;
        }

        public static Boolean ExisteMetodoPago(int idMetodoPago)
        {
            listaMetodoPago = ObtenerMetodosPagos();
            return listaMetodoPago.Count(x => x.IdMetodoPago == idMetodoPago) > 0 ? true : false;
        }

    }
}
