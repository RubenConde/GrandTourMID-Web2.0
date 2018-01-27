using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class ComentPubDAO:ConexionSQL
    {
        public DataTable CargarComentPub()
        {
            string sql = string.Format("Select * from comentpub");
            return EjercutarSentenciaBusqueda(sql);
        }

    }
}