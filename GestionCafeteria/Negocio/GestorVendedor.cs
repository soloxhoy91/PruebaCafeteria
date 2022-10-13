using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Negocio
{
    internal class GestorVendedor
    {
        private static GestorDB gs = new GestorDB();
        private static List<Vendedor> listaVendedor = new List<Vendedor>();

        public GestorVendedor()
        {
            if (gs == null)
            {
                gs = new GestorDB();
            }
        }

        public static String InsertarVendedor(Vendedor nuevo)
        {
            string ret = "";
            if (!existeVendedor(nuevo.IdVendedor))
            {
                try
                {
                    string query = "INSERT INTO Vendedor VALUES (" + nuevo.IdVendedor + ", '" + nuevo.Nombre + "',True)";
                    gs.QueryNonQuery(query);

                    ret = "Vendedor registrado con exito.";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;

                }
            }
            else
            {
                ret = "El vendedor con el codigo " + nuevo.IdVendedor + " ya existe";
            }
            return ret;

        }

        public static List<Vendedor> ObtenerVendedores()
        {
            string query = "select * from Vendedor";
            DataTable dt = gs.QueryReader(query);
            List<Vendedor> lista = new List<Vendedor>();

            foreach (DataRow item in dt.Rows)
            {
                Vendedor vendedor = new Vendedor();
                vendedor.IdVendedor = Convert.ToInt32(item["IdVendedor"].ToString());
                vendedor.Nombre = item["Nombre"].ToString();
                vendedor.Activo = Convert.ToBoolean(item["Activo"].ToString());
                lista.Add(vendedor);
            }
            return lista;
        }

        public static Vendedor ObtenerVendedor(int idVendedor)
        {

            string query = "select * from Vendedor where IdVendedor= " + idVendedor;
            DataTable dt = gs.QueryReader(query);
            Vendedor vendedor = new Vendedor();
            foreach (DataRow item in dt.Rows)
            {
                if (idVendedor == Convert.ToInt32(item["IdVendedor"].ToString))
                {
                    vendedor.IdVendedor = Convert.ToInt32(item["IdVendedor"].ToString());
                    vendedor.Nombre = item["Nombre"].ToString();
                    vendedor.Activo = Convert.ToBoolean(item["Activo"].ToString());
                }
            }
            return vendedor;
        }


        public static Boolean existeVendedor(int IdVendedor)
        {
            listaVendedor = ObtenerVendedores();

            return listaVendedor.Count(x => x.IdVendedor == IdVendedor) > 0 ? true : false;
        }
    }
}
