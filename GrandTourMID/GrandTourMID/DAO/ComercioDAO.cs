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

        public DataTable VerPublicidades()
        {
            string sql = string.Format("select * from cupon");
            return EjercutarSentenciaBusqueda(sql);
        }

        public int AddPublicidad(ComercioBO objelug)
        {
            cmd = new SqlCommand("insert into lugares  (cantidad, fecha, cover, descripcion) values (@cantidad, @fecha, @cover, @descripcion)");
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = objelug.cantidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = objelug.fecha;
            cmd.Parameters.Add("@cover", SqlDbType.VarChar).Value = objelug.cover;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = objelug.descripcion;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

    }
}