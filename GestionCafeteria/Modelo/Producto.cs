using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class Producto
    {
        public Producto()
        {
            this.IdProducto = 0;
            this.Nombre = "";
            this.PrecioUnitario = 0;
            this.Activo = true;
            this.Ingredientes = new List<Ingrediente>();
        }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Activo { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public String IngredientesToString()
        {
            string aux = "";
            for (int i = 0; i < Ingredientes.Count(); i++)
            {
                aux += '\n' + Ingredientes[i].ToString();
            }
            return aux;
        }
    }
}
