using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionCafeteria.Presentacion;

namespace GestionCafeteria.Negocio
{
    internal class GestorProductos
    {
        private static GestorDB gs = new GestorDB();
        private static List<Producto> _products = new List<Producto>();
        public GestorProductos()
        {
            if (gs == null)
            {
                gs = new GestorDB();
            }
        }
        public static Producto ObtenerProducto(int idProducto)
        {

            //gs.PruebaDeConexion(3);
            string query = "select * from Producto where IdProducto= " + idProducto;
            DataTable dt = gs.QueryReader(query);
            Producto producto = new Producto();
            foreach (DataRow item in dt.Rows)
            {
                producto.IdProducto = Convert.ToInt32(item["IdProducto"].ToString());
                producto.Nombre = item["Nombre"].ToString();
                producto.Ingredientes = new List<Modelo.Ingrediente>();
                producto.PrecioUnitario = Convert.ToDecimal(item["PrecioUnitario"].ToString());
                producto.Activo = Convert.ToBoolean(item["Activo"].ToString());
            }
            return producto;
        }
        public static List<Producto> ObtenerProductos()
        {
            string query = "select * from Producto ";
            DataTable dt = gs.QueryReader(query);
            List<Producto> lista = new List<Producto>();
            foreach (DataRow item in dt.Rows)
            {
                Producto aux = new Producto();
                aux.IdProducto = Convert.ToInt32(item["IdProducto"].ToString());
                aux.Nombre = item["Nombre"].ToString();
                aux.Ingredientes = new List<Modelo.Ingrediente>();
                aux.PrecioUnitario = Convert.ToDecimal(item["PrecioUnitario"].ToString());
                aux.Activo = Convert.ToBoolean(item["Activo"].ToString());
                lista.Add(aux);
            }
            return lista;

        }
        public static string InsertarProducto(Producto nuevo)
        {
            string ret;
            if (!ExistProducto(nuevo.IdProducto))
            {
                try
                {
                    _products.Add(nuevo);
                    ret = "Producto registrado con exito.";
                }
                catch (Exception ex)
                {
                    ret = ex.Message;

                }
            }
            else
            {
                ret = "El producto con le codigo " + nuevo.IdProducto + " ya existe";
            }
            return ret;
        }

        public static string ActualizarProducto(Producto actualizar)
        {
            if (ExistProducto(actualizar.IdProducto))//existe un producto en los registros de productos que tenga el mismo id
            {
                try
                {
                    //  var aux = ObtenerProducto(actualizar.IdProducto);
                    int i = _products.FindIndex(x => x.IdProducto == actualizar.IdProducto);
                    _products[i] = actualizar;

                    return "Producto actualizado con exito.";
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }
                //actualizar el producto de la tabla de registros.
            }
            else
            {
                return "No se encontro producto registrado con el codigo " + actualizar.IdProducto + " para ser actualizado.";
            }
        }
        public static string EliminarProducto(int idCodigo)
        {
            if (ExistProducto(idCodigo))//existe un producto en los registros de productos que tenga el mismo id
            {
                var aux = ObtenerProducto(idCodigo);
                _products.Remove(aux);
                return "Elemento eliminado con exito.";
                //elimino el producto de la tabla de registros.
            }
            else
            {
                return "No existe elemento registrado con el codigo " + idCodigo + " para ser eliminado.";
            }

        }
        private static bool ExistProducto(int idProducto)
        {

            return _products.Count(x => x.IdProducto == idProducto) > 0 ? true : false;
        }
        public static void CargarProductosDePrueba()
        {

            _products.Add(new Producto() { IdProducto = 1, Nombre = "Cafe", PrecioUnitario = 280, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 2, Nombre = "Cafe con leche", PrecioUnitario = 280, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 3, Nombre = "Cortado", PrecioUnitario = 250, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 4, Nombre = "Capuchino", PrecioUnitario = 350, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 5, Nombre = "Cafe Irlandes", PrecioUnitario = 375, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 6, Nombre = "Medialuna", PrecioUnitario = 100, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 7, Nombre = "Criollito", PrecioUnitario = 50, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 8, Nombre = "Carlito", PrecioUnitario = 300, Ingredientes = new List<Ingrediente>() });
            _products.Add(new Producto() { IdProducto = 9, Nombre = "Mafalda", PrecioUnitario = 250, Ingredientes = new List<Ingrediente>() });
            // _products[0].Ingredientes.Add();

        }
    }

}
