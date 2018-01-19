using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class PublicacionDAO:ConexionSQL
    {
        SqlCommand cmd = new SqlCommand();

        public DataTable CargarPublicaciones()
        {
            string sql = string.Format("Select p.idpublicacion, u.nombre, u.foto, u.idusuario, p.texto, p.img, p.img2, p.img3, p.fechapub from usuario u, publicacion p where u.idusuario = p.idusuario order by p.idpublicacion desc");
            return EjercutarSentenciaBusqueda(sql);

        }

        public int AgregarPublicacion(PublicacionBO objeus)
        {
            cmd = new SqlCommand("insert into publicacion (idusuario, texto, img,img2,img3) values (@idus, @texto, @img, @img2, @img3)");
            cmd.Parameters.Add("@idus", SqlDbType.Int).Value = objeus.idusuario;
            cmd.Parameters.Add("@texto", SqlDbType.VarChar).Value = objeus.texto;
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objeus.img;
            cmd.Parameters.Add("@img2", SqlDbType.VarChar).Value = objeus.img2;
            cmd.Parameters.Add("@img3", SqlDbType.VarChar).Value = objeus.img3;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }
























    }
}