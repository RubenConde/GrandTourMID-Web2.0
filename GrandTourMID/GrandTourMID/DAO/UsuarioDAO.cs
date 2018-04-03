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
            cmd = new SqlCommand("INSERT INTO Usuario(nombre, usuario, contrasenia, email, idtipo, fecharegistro) values(@nombre, @usuario, @contrasenia, @email, @idtipo, getdate())");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = objeus.usuario;
            cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = objeus.EncriptarMD5(objeus.contraseña);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.Parameters.Add("@idtipo", SqlDbType.VarChar).Value = 2;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int AgregarAdmin(UsuarioBO objeus)
        {
            cmd = new SqlCommand("INSERT INTO Usuario(nombre, usuario, contrasenia, email, idtipo, fecharegistro) values(@nombre, @usuario, @contrasenia, @email, @idtipo, getdate())");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = objeus.usuario;
            cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = objeus.EncriptarMD5(objeus.contraseña);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.Parameters.Add("@idtipo", SqlDbType.VarChar).Value = 1;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int AgregarComercio(UsuarioBO objeus)
        {
            cmd = new SqlCommand("INSERT INTO Usuario(nombre, rfc, usuario, contrasenia, email, idtipo, fecharegistro) values(@nombre, @rfc, @usuario, @contrasenia, @email, @idtipo, getdate())");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
            cmd.Parameters.Add("@rfc", SqlDbType.VarChar).Value = objeus.rfc;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = objeus.usuario;
            cmd.Parameters.Add("@contrasenia", SqlDbType.VarChar).Value = objeus.EncriptarMD5(objeus.contraseña);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objeus.email;
            cmd.Parameters.Add("@idtipo", SqlDbType.Int).Value = 3;
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
            cmd = new SqlCommand("Update usuario set nombre=@nombre, usuario=@usuario, email=@email where idusuario=@id");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objeus.nombre;
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
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.usuario, u.contrasenia, u.foto, u.email, t.nombre as rol, u.rfc FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and idusuario = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUserComercio(int id)
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.usuario, u.contrasenia, u.foto, u.email, t.nombre as rol, u.rfc FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and idusuario = '{0}'", id);
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
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.usuario as Usuario, u.foto as Foto, u.Email, CONVERT(varchar, u.fecharegistro, 107) as fecharegistro FROM usuario u where idtipo = 1");
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable BuscarUsuariosRegistrados()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.usuario as Usuario, u.foto as Foto, u.Email, CONVERT(varchar, u.fecharegistro, 107) as fecharegistro FROM usuario u where estado = 1");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUsuariosInactivos()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.usuario as Usuario, u.foto as Foto, u.Email, CONVERT(varchar, u.fecharegistro, 107) as fecharegistro FROM usuario u where u.estado = 2");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUsuariosBloquedos()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.usuario as Usuario, u.foto as Foto, u.Email, CONVERT(varchar, u.fecharegistro, 107) as fecharegistro FROM usuario u where estado = 3");
            return EjercutarSentenciaBusqueda(sql);

        }


        public DataTable BuscarUsuariosComercio()
        {
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.rfc, u.usuario as Usuario, u.foto as Foto, u.Email, CONVERT(varchar, u.fecharegistro, 107) as fecharegistro FROM usuario u where idtipo = 3");
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
            string sql = string.Format("SELECT u.idusuario as ID, u.nombre as Nombre, u.usuario as Usuario, u.foto as Foto, u.estado from usuario u, tipo t WHERE t.idtipo = u.idtipo and u.estado = 1");
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable BuscarUsuarioInactivo()
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.usuario, u.contrasenia, u.foto, email, t.nombre as rol FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and u.estado = 0 ");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarUsuarioBloqueado()
        {
            string sql = string.Format("SELECT u.idusuario, u.nombre as nombreus, u.usuario, u.contrasenia, u.foto, email, t.nombre as rol FROM tipo t, usuario u WHERE t.idtipo = u.idtipo and u.estado =2");
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

        

        public string TipoDeEstado(string email)
        {
            string columna = "estado";
            string sql = string.Format("select * from usuario where email = '{0}'", email);

            return EjectuadorComandosDatoEspecifico(sql, columna);

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