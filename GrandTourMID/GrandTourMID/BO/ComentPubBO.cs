using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandTourMID.BO
{
    public class ComentPubBO
    {
        public int idcomentpub { get; set; }
        public string comentpub { get; set; }
        public int idpublic { get; set; }
        public int iduser { get; set; }
        public string cover { get; set; }
        public int cantidad { get; set; }
        public string fecha { get; set; }


    }
}