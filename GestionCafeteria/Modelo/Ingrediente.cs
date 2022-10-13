using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class Ingrediente
    {
        public Ingrediente()
        {
            this.IdIngrediente = 0;
            this.Cantidad = 0;
            this.NombreIngrediente = "";
            this.UnidadMedida = "";
        }
        public int IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        override
        public string ToString() {
            return this.NombreIngrediente + " cantidad: " + this.Cantidad;        
        }
    }
}
