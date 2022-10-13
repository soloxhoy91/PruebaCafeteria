using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class Vendedor
    {
        public Vendedor()
        {
            this.IdVendedor = 0;
            this.Nombre = "";
            this.Activo = true;
        }

        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public Boolean Activo { get; set; }

    }
}
