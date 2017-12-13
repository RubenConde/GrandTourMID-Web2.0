using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class PublicacionDAO:ConexionSQL
    {

        public DataTable CargarPublicaciones(int numero)
        {
            string sql = string.Format("Select top "+numero+" idpublicacion, idusuario, texto, img from publicacion order by idpublicacion desc");
            return EjercutarSentenciaBusqueda(sql);

        }

























    }
}