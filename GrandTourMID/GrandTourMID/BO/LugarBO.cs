using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTourMID.BO
{
    public class LugarBO
    {
        public int idlugar { get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string informacionapp { get; set; }
        public string informacionweb { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string direccion { get; set; }
        public string imagen { get; set; }
        public string direccionmaps { get; set; }
        public int idtipo { get; set; }
        public byte[] icono { get; set; }



    }
}