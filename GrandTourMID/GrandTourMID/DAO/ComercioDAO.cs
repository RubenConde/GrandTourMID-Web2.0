using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class ComercioDAO : ConexionSQL
    {
        SqlCommand cmd;

        public int ActualizarFoto(UsuarioBO objeus)
        {
            cmd = new SqlCommand("Update comercio set imagen=@foto where idcomercio=@id");
            cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = objeus.imagen;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objeus.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }

        public DataTable BuscarComercio(int id)
        {
            string sql = string.Format("SELECT u.nombre, u.dirprincipal, u.imagen FROM comercio u WHERE idcomercio = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);

        }

        public int Actualizarinfocomer(ComercioBO objcomercio)
        {
            cmd = new SqlCommand("Update usuario set nombre=@nombre, dirprincipal=@dirprin where idcomercio=@id");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objcomercio.nombrecomer;
            cmd.Parameters.Add("@dirprin", SqlDbType.VarChar).Value = objcomercio.dirprincomer;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = objcomercio.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }

        public DataTable VerPublicidades1(int iduser)
        {
            string sql = string.Format("select c.cover, c.descripcion, c.cantidad, c.fecha, c.canjeos from cupon c join usuario u on c.idusuario = u.idusuario where c.idusuario = '{0}' and c.estado = 1", iduser);

            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable VerPublicidades2(int iduser)
        {
            string sql = string.Format("select c.cover, c.descripcion, c.cantidad, c.fecha, c.canjeos from cupon c join usuario u on c.idusuario = u.idusuario where c.idusuario = '{0}' and c.estado = 0", iduser);

            return EjercutarSentenciaBusqueda(sql);
        }


        public int AddPublicidad(ComercioBO objelug)
        {
            cmd = new SqlCommand("insert into cupon  (cantidad, fecha, cover, descripcion, idusuario) values (@cantidad, @fecha, @cover, @descripcion, @idusuario)");
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = objelug.cantidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = objelug.fecha;
            cmd.Parameters.Add("@cover", SqlDbType.VarChar).Value = objelug.cover;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = objelug.descripcion;
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = objelug.idusuario;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

    }

}