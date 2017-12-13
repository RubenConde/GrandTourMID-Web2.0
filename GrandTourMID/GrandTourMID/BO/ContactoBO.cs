using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTourMID.BO
{
    public class ContactoBO
    {
        public int idcontacto { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public string direccion { get; set; }
        public string numero { get; set; }
        public string correo { get; set; }
        public string mensaje { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public int visto { get; set; }
        public string nombre { get; set; }
        public string asunto { get; set; }
        public string para { get; set; }
    }
}