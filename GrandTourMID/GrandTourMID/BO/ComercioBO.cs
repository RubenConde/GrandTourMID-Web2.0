﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTourMID.BO
{
    public class ComercioBO
    {
        public string cover { get; set; }
        public int cantidad { get; set; }
        public string fecha { get; set; }
        public string descripcion { get; set; }
        public int idusuario { get; set; }
        public int idcupon { get; set; }
        public string cupon64 { get; set; }
        public string nombrecupon { get; set; }
        public string condiciones { get; set; }
        public int codigocupon { get; set; }



        public string imagencomercio { get; set; }
        public string nombrecomer { get; set; }
        public string dirprincomer { get; set; }
        public int id { get; set; }

    }
}