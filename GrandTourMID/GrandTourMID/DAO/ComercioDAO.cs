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


        public int Actualizarinfocomer(ComercioBO objcomercio)
        {
            cmd = new SqlCommand("Update usuario set nombre=@nombre, dirprincipal=@dirprin where idcomercio=@id");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objcomercio.nombrecomer;
            cmd.Parameters.Add("@dirprin", SqlDbType.VarChar).Value = objcomercio.dirprincomer;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = objcomercio.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }



        public int ActualizarCUPON(ComercioBO objcomercio)
        {
            cmd = new SqlCommand("Update cupon set cantidad=@cantidad, fecha=@fecha, cover=@cover, descripcion=@descripcion, nombrecupon=@nombrecupon, condiciones=@condiciones where idcupon=@id");
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = objcomercio.cantidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = objcomercio.fecha;
            cmd.Parameters.Add("@cover", SqlDbType.VarChar).Value = objcomercio.cover;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = objcomercio.descripcion;
            cmd.Parameters.Add("@nombrecupon", SqlDbType.VarChar).Value = objcomercio.nombrecupon;
            cmd.Parameters.Add("@condiciones", SqlDbType.VarChar).Value = objcomercio.condiciones;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objcomercio.idcupon;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }
        public int ActualizarCUPONsinimagen(ComercioBO objcomercio)
        {
            cmd = new SqlCommand("Update cupon set cantidad=@cantidad, fecha=@fecha, descripcion=@descripcion, nombrecupon=@nombrecupon, condiciones=@condiciones where idcupon=@id");
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = objcomercio.cantidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = objcomercio.fecha;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = objcomercio.descripcion;
            cmd.Parameters.Add("@nombrecupon", SqlDbType.VarChar).Value = objcomercio.nombrecupon;
            cmd.Parameters.Add("@condiciones", SqlDbType.VarChar).Value = objcomercio.condiciones;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objcomercio.idcupon;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }
        public int ActualizarCUPONcanjeo(int idobtencion)
        {
            cmd = new SqlCommand("Update usuarioXcupon set estado=1 where idobtencioncupon=@id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idobtencion;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }
        public string Obteneridcupon(int idobtencion)
        {
            string columna = "idcupon";
            string sql = string.Format("select idcupon from usuarioXcupon where idobtencioncupon = {0}", idobtencion);

            return EjectuadorComandosDatoEspecifico(sql, columna);
        }


        public string VerifCupon(int idcupon)
        {
            string columna = "cuenta";
            string sql = string.Format("select count(*) as cuenta from cupon where idcupon = {0} and aprobado = 1", idcupon);

            return EjectuadorComandosDatoEspecifico(sql, columna);
        }


        public int Aprobarcupon(int idcupon)
        {
            cmd = new SqlCommand("Update cupon set aprobado=1 where idcupon=@idcupon");
            cmd.Parameters.Add("@idcupon", SqlDbType.Int).Value = idcupon;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }

        public int Desaprobarcupon(int idcupon)
        {
            cmd = new SqlCommand("Update cupon set aprobado=0 where idcupon=@idcupon");
            cmd.Parameters.Add("@idcupon", SqlDbType.Int).Value = idcupon;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }



        public DataTable Verinfocupon(int idcupon)
        {
            string sql = string.Format("select idcupon, cantidad, CONVERT(varchar, fecha, 103) as fecha, cover, descripcion, nombrecupon, condiciones from cupon where idcupon = '{0}'", idcupon);

            return EjercutarSentenciaBusqueda(sql);
        }
        public DataTable Verinfocuponcanjeo(int idcupon)
        {
            string sql = string.Format("select idcupon, cantidad, CONVERT(varchar, fecha, 103) as fecha, cover, descripcion, nombrecupon, condiciones from cupon where idcupon = '{0}'", idcupon);

            return EjercutarSentenciaBusqueda(sql);
        }


        public DataTable VerCuponesDes()
        {
            string sql = string.Format("select c.idcupon, c.cover, c.descripcion, u.nombre from cupon c join usuario u on c.idusuario = u.idusuario where c.aprobado = 0");

            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable VerCuponesApr()
        {
            string sql = string.Format("select c.idcupon, c.cover, c.descripcion, u.nombre from cupon c join usuario u on c.idusuario = u.idusuario where c.aprobado = 1");

            return EjercutarSentenciaBusqueda(sql);
        }


        public DataTable VerPublicidades1(int iduser)
        {
            string sql = string.Format("select c.idcupon, c.cover, c.descripcion, c.cantidad, CONVERT(varchar, c.fecha, 107) as fecha, c.canjeos from cupon c join usuario u on c.idusuario = u.idusuario where c.idusuario = '{0}' and c.estado = 0", iduser);

            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable VerPublicidades2(int iduser)
        {
            string sql = string.Format("select c.cover, c.descripcion, c.cantidad, CONVERT(varchar, c.fecha, 107) as fecha, c.canjeos from cupon c join usuario u on c.idusuario = u.idusuario where c.idusuario = '{0}' and c.estado = 1", iduser);

            return EjercutarSentenciaBusqueda(sql);
        }
        public DataTable Galeria(int iduser, int idlugar)
        {
            string sql = string.Format("SELECT f.*, l.* FROM UsuarioFotos uf JOIN Fotos f ON f.idfoto = uf.idfoto JOIN lugares l ON l.idlugar = uf.idlugar WHERE uf.idlugar = {0} AND uf.idusuario = {1}", idlugar, iduser);

            return EjercutarSentenciaBusqueda(sql);
        }


        public int AddPublicidad(ComercioBO objelug)
        {
            cmd = new SqlCommand("insert into cupon  (cantidad, fecha, cover, descripcion, idusuario, nombrecupon, condiciones) values (@cantidad, @fecha, @cover, @descripcion, @idusuario, @nombre, @condiciones)");
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = objelug.cantidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = objelug.fecha;
            cmd.Parameters.Add("@cover", SqlDbType.VarChar).Value = objelug.cover;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = objelug.descripcion;
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = objelug.idusuario;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombrecupon;
            cmd.Parameters.Add("@condiciones", SqlDbType.VarChar).Value = objelug.condiciones;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

    }

}