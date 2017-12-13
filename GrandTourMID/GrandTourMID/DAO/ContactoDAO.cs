using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class ContactoDAO : ConexionSQL
    {
        SqlCommand cmd;


        public int AgregarInfoContacto(ContactoBO objec)
        {
            cmd = new SqlCommand("Update Contacto set titulo = @titu, subtitulo=@sub, direccion=@dire, numero=@numero, correo=@correo, mensaje=@mensaje, longitud=@lon, latitud=@lat where idcontacto=1");
            cmd.Parameters.Add("@titu", SqlDbType.VarChar).Value = objec.titulo;
            cmd.Parameters.Add("@sub", SqlDbType.VarChar).Value = objec.subtitulo;
            cmd.Parameters.Add("@dire", SqlDbType.VarChar).Value = objec.direccion;
            cmd.Parameters.Add("@numero", SqlDbType.VarChar).Value = objec.numero;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = objec.correo;
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = objec.mensaje;
            cmd.Parameters.Add("@lon", SqlDbType.VarChar).Value = objec.lon;
            cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = objec.lat;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


        public DataTable CargarInfoContacto()
        {
            string sql = string.Format("select titulo, subtitulo, direccion, numero, correo, mensaje, longitud, latitud from Contacto where idcontacto=1");
            return EjercutarSentenciaBusqueda(sql);

        }



        public int MensajeDeContacto(ContactoBO objec)
        {
            cmd = new SqlCommand("insert into MensajeContacto(nombre, email, mensaje) values(@nombre, @correo, @mensaje )");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objec.nombre;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = objec.correo;
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = objec.mensaje;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int EnviarCorreo(ContactoBO objec)
        {
            cmd = new SqlCommand("insert into Correo (para, motivo, mensaje)values(@para, @motivo, @mensaje)");
            cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = objec.para;
            cmd.Parameters.Add("@motivo", SqlDbType.VarChar).Value = objec.asunto;
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = objec.mensaje;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public DataTable InboxRecibidos()
        {
            string sql = string.Format("select idmensaje, nombre, email, mensaje, fecha from MensajeContacto where visto=0");
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable NumeroInbox()
        {
            string sql = string.Format("select COUNT(mensaje) as mensaje from MensajeContacto where visto=0");
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable NumeroInboxLeido()
        {
            string sql = string.Format("select COUNT(mensaje) as mensaje from MensajeContacto where visto=1");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable InboxVistos()
        {
            string sql = string.Format("select idmensaje, nombre, email, mensaje, fecha from MensajeContacto where visto=1");
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable Vermensaje(ContactoBO objec)
        {
            string sql = string.Format("select idmensaje, nombre, email, mensaje, fecha from MensajeContacto where idmensaje='{0}'", objec.idcontacto);
            return EjercutarSentenciaBusqueda(sql);
        }


        public int MensajeLeido(ContactoBO objec)
        {
            cmd = new SqlCommand("update MensajeContacto set visto=1 where idmensaje=@id ");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objec.idcontacto;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


        public DataTable NumeroEnviado()
        {
            string sql = string.Format("select COUNT(mensaje) as mensaje from Correo");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable InboxEnviado()
        {
            string sql = string.Format("select idcorreo, para, motivo, mensaje from Correo");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable Verinboxenviado(ContactoBO objec)
        {

            string sql = string.Format("select idcorreo, para, motivo, mensaje, fecha from Correo where idcorreo='{0}'", objec.idcontacto);
            return EjercutarSentenciaBusqueda(sql);

        }






    }
}