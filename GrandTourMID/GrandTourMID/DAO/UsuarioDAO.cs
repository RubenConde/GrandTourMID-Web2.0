    using GrandTourMID.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class UsuarioDAO : ConexionSQL
    {
        SqlCommand cmd;

        public int Agregar(UsuarioBO objeus)
        {
            cmd = new SqlCommand("INSERT INTO Usuario(nombre, apellidop, apellidom, usuario, contrasenia, email) values(@nombre, @apellidop, @apellidom, @usuario, @contrasenia, @email)");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@apellidop", SqlDbType.VarChar).Value = objeus.apellidop;
            cmd.Parameters.Add("@apellidom", SqlDbType.VarChar).Value = objeus.apellidom;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = objeus.usuario;
            cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = objeus.EncriptarMD5(objeus.contraseña);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarFotou(UsuarioBO objeus)
        {
            cmd = new SqlCommand("Update usuario set foto=@foto where idusuario=@id");
            cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = objeus.imagen;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objeus.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }

        public int Actualizarinfoadmi(UsuarioBO objeus)
        {
            cmd = new SqlCommand("Update usuario set nombre=@nombre, apellidop=@apep, usuario=@usuario, apellidom=@apem, email=@email where idusuario=@id");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@apep", SqlDbType.VarChar).Value =objeus.apellidop;
            cmd.Parameters.Add("@apem", SqlDbType.VarChar).Value = objeus.apellidom;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = objeus.usuario;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = objeus.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }
        public int Actualizarinfocomer(UsuarioBO objeus)
        {
            cmd = new SqlCommand("Update usuario set nombre=@nombre, email=@email where idusuario=@id");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = objeus.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);


        }


        public int ModificarContraseña(UsuarioBO objeus)
        {
            cmd = new SqlCommand("Update usuario set contrasenia=@contra where idusuario=@id");
            cmd.Parameters.Add("@contra", SqlDbType.VarChar).Value = objeus.EncriptarMD5(objeus.contraseña);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objeus.id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


        public DataTable BuscarUser(int id)
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.apellidop, u.apellidom,u.usuario, u.contrasenia, u.foto, u.email, t.nombre as rol, u.rfc FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and idusuario = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);

        }

        public ArrayList BuscarUsuario(UsuarioBO objeus)
        {
            string comando = string.Format("SELECT usuario.idusuario, usuario.nombre, usuario.idtipo, usuario.foto, usuario.estado FROM usuario  WHERE usuario.idusuario='{0}'", objeus.id);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["idusuario"].ToString());
                tipous.Add(lectura["nombre"].ToString());
                tipous.Add(lectura["foto"].ToString());

            }
            cerrarconexion();
            return tipous;

        }

        public ArrayList ValidarContraseña(UsuarioBO objeus)
        {
            string comando = string.Format("SELECT contrasenia FROM usuario WHERE idusuario = '{0}'", objeus.id);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["contrasenia"].ToString());
            }
            cerrarconexion();
            return tipous;
        }


        public DataTable BuscarUsuariosTodos()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.apellidop as ApellidoP, u.apellidom as ApellidoM, u.usuario as Usuario, u.foto as Foto, u.Email, u.fecharegistro FROM usuario u");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable NumeroUsuarios()
        {
            string sql = string.Format("select COUNT(idusuario) as usuario from usuario where estado=1 and idtipo = 2");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable ValidarRegistroUsuario(UsuarioBO objus)
        {
            string sql = string.Format("select idusuario from usuario where usuario = '"+objus.usuario+"'");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable ValidarRegistroEmail(UsuarioBO objus)
        {
            string sql = string.Format("select idusuario from usuario where email = '" + objus.email + "'");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUsuarioActivo()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.apellidop as ApellidoP, u.apellidom as ApellidoM, u.usuario as Usuario, u.foto as Foto, u.estado from usuario u, tipo t WHERE t.idtipo = u.idtipo and u.estado = 1");
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable BuscarUsuarioInactivo()
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.apellidop, u.apellidom,u. usuario, u.contrasenia, u.foto, email, t.nombre as rol FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and u.estado = 0 ");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUsuarioBloqueado()
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.apellidop, u.apellidom,u. usuario, u.contrasenia, u.foto, email, t.nombre as rol FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and u.estado =2");
            return EjercutarSentenciaBusqueda(sql);

        }


        public DataTable MostrarEmpleados()
        {
            string sql = string.Format("select u.nombre, t.nombre as rol, u.fecha, u.edad from usuario u, tipo t where u.idtipo = t.idtipo and t.idtipo= 1");
            return EjercutarSentenciaBusqueda(sql);

        }


        public int ActualizarCodigo(CorreoBO objec)
        {
            cmd = new SqlCommand("update usuario set codigor=@codigo where email=@correo");
            cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = objec.codigo;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = objec.email;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        

        public ArrayList TipoDeEstado(CorreoBO objec)
        {
            string comando = string.Format("SELECT estado FROM usuario WHERE email = '{0}'", objec.email);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["estado"].ToString());
            }
            cerrarconexion();
            return tipous;

        }


        public ArrayList ValidarCodigo(CorreoBO objec)
        {
            string comando = string.Format("SELECT usuario.idusuario from usuario WHERE usuario.codigor = '{0}'", objec.codigo);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["idusuario"].ToString());
            }
            cerrarconexion();
            return tipous;

        }



        public int Foto(UsuarioBO objeus)
        {
            cmd = new SqlCommand("insert into fotitos(img)values(@img)");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objeus.imagen;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }


        public int DesactivarCuenta(int id)
        {
            cmd = new SqlCommand("update usuario set estado=0 where idusuario=@id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


      


    }
}