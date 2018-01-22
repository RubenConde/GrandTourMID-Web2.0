using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class ComentarioDAO:ConexionSQL
    {

        public DataTable CargarComentarios()
        {
            string sql = string.Format("select u.foto, u.nombre, c.comentario, c.fecha from usuario u, comentarios c where u.idusuario = c.idusuario");
            return EjercutarSentenciaBusqueda(sql);
        }



    }
}