using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCafeteria.Modelo
{
    internal class MetodoPago
    {
        public MetodoPago()
        {
            this.IdMetodoPago = 0;
            this.Nombre = "";
            this.Recargo = 0;
            this.Activo = false;
        }
        public int IdMetodoPago { get; set; }
        public string Nombre { get; set; }
        public int Recargo { get; set; }
        public bool Activo { get; set; }    
    }
}
