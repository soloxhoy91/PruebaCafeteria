using GestionCafeteria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Negocio
{
    internal class GestorIngredientes
    {
        public static List<Ingrediente> _ingredientes = new List<Ingrediente>();

        public static Ingrediente ObtenerIngrediente(int idIngrediente)
        {
            if (ExistIngrediente(idIngrediente))
            {
                return _ingredientes.Where(x => x.IdIngrediente == idIngrediente).First();
            }
            else
            {
                return new Ingrediente();
            }

        }
        public static List<Ingrediente> ObtenerIngredientes()
        {
            return _ingredientes.ToList();
        }
        public static string InsertarIngrediente(Ingrediente nuevo)
        {
            if (!ExistIngrediente(nuevo.IdIngrediente))
            {
                try
                {
                    _ingredientes.Add(nuevo);
                    return "Ingrediente registrado con exito";
                }
                catch (Exception ex)
                {
                    return ex.Message;

                }
            }
            else
            {
                return "Existe un ingrediente registrado con el codigo " + nuevo.IdIngrediente;
            }
        }
        public static string ActualizarIngrediente(Ingrediente actualizar)
        {
            if (ExistIngrediente(actualizar.IdIngrediente))
            {
                int i = _ingredientes.FindIndex(x => x.IdIngrediente == actualizar.IdIngrediente);
                _ingredientes[i] = actualizar;
                return "Ingrediente actualizado con exito.";
            }
            else
            {
                return "No existe elemento registrado con el codigo " + actualizar.IdIngrediente + " para ser actualizado.";
            }
        }
        public static string EliminarIngrediente(int idIngrediente)
        {
            if (ExistIngrediente(idIngrediente))
            {
                var aux = ObtenerIngrediente(idIngrediente);
                _ingredientes.Remove(aux);
                return "Ingrediente eliminado con exito.";
            }
            else
            {
                return "No existe Ingrediente con el codigo "+idIngrediente+" para ser eliminado";
            }
        }

        public static bool ExistIngrediente(int idIngrediente)
        {
            return _ingredientes.Count(x => x.IdIngrediente == idIngrediente) > 0 ? true : false;
        }
        public static void CargarIngredientesPrueba()
        {
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 1, NombreIngrediente = "cafe molido",UnidadMedida="Gramos", Cantidad =50});
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 2, NombreIngrediente = "Leche", UnidadMedida = "Mililitros", Cantidad = 50 });
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 3, NombreIngrediente = "Canela", UnidadMedida = "Gramos", Cantidad = 25 });
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 4, NombreIngrediente = "Chocolate", UnidadMedida = "Gramos", Cantidad = 45 });
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 5, NombreIngrediente = "Whiskey", UnidadMedida = "Mililitros", Cantidad = 25});
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 6, NombreIngrediente = "Crema de leche", UnidadMedida = "Gramos", Cantidad = 50});
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 7, NombreIngrediente = "Pan de miga", UnidadMedida = "Unidad", Cantidad = 2});
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 8, NombreIngrediente = "Jamon", UnidadMedida = "Gramos", Cantidad = 75 });
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 9, NombreIngrediente = "Queso", UnidadMedida = "Gramos", Cantidad = 75 });
            _ingredientes.Add(new Ingrediente() { IdIngrediente = 10, NombreIngrediente = "Medialuna", UnidadMedida = "Unidad", Cantidad = Convert.ToDecimal(1) });
            
            //_ingredientes.Add(new Ingrediente() { IdIngrediente = 6, NombreIngrediente = "", Precio = , Cantidad = Convert.ToDecimal(50) });

        }
    }
}
