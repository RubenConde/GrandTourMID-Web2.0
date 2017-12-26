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
    public class ChatDAO:ConexionSQL
    {
        public DataTable usersChat(UsuarioBO obelogin)
        {
            String comandoSQL = string.Format("select u.email, u.idusuario as ID, u.nombre, u.foto   from usuario u, chat c   where c.idenvia <> {0} and u.idusuario = c.idenvia and c.idrecibe ={0}", obelogin.id);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoSQL, establecerConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        public DataTable UltimoMensaje()
        {
            string sql = string.Format("select MAX(mensaje) as mensaje from mensaje");
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable MsgChat(UsuarioBO obelogin)
        {
            String comandoSQL = string.Format("SELECT * from msg where (idenvia={0} and idrecibe={1}) or (idenvia={1} and idrecibe={0})", obelogin.idchat, obelogin.id);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoSQL, establecerConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public ArrayList idChat(UsuarioBO obelogin)
        {

            string comando = string.Format("Select idchat from mgs2 where idenvia={0} and idrecibe={1}", obelogin.id, obelogin.idchat);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["idchat"].ToString());

            }
            cerrarconexion();
            return tipous;
        }

        public ArrayList Chat(UsuarioBO obelogin)
        {

            string comando = string.Format("select  u.idusuario as ID, u.nombre, u.foto   from usuario u, chat c   where c.idenvia <> {0} and u.idusuario = c.idenvia and c.idrecibe ={0}", obelogin.id);
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["ID"].ToString());
                tipous.Add(lectura["nombre"].ToString());
                tipous.Add(lectura["foto"].ToString());
            }
            cerrarconexion();
            return tipous;
        }

        public int iniciarChat(UsuarioBO objeus)
        {
            SqlCommand cmd = new SqlCommand("Insert into chat(idrecibe, idenvia) output inserted.idChat values (@recibee, @enviaa)");
            cmd.Parameters.Add("@recibee", SqlDbType.Int).Value = objeus.idrecibe;
            cmd.Parameters.Add("@enviaa", SqlDbType.Int).Value = objeus.idenvia;

            cmd.CommandType = CommandType.Text;
            int idchat = EjecutarComando(cmd);

            cmd = new SqlCommand("insert into Mensajes (idchat, visto, mensaje) values (@chatt,@vistoo,@mensajee)");
            cmd.Parameters.Add("@vistoo", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@mensajee", SqlDbType.VarChar).Value = objeus.mensaje;
            cmd.Parameters.Add("@chatt", SqlDbType.VarChar).Value = idchat;


            cmd.CommandType = CommandType.Text;

            EjecutarComando(cmd);
            SqlCommand cmdd = new SqlCommand("Insert into chat(idrecibe, idenvia) output inserted.idChat values (@recibe, @envia)");
            cmdd.Parameters.Add("@recibe", SqlDbType.Int).Value = objeus.idenvia;
            cmdd.Parameters.Add("@envia", SqlDbType.Int).Value = objeus.idrecibe;
            cmdd.CommandType = CommandType.Text;

            int recibe = EjecutarComando(cmdd);
            cmdd = new SqlCommand("insert into Mensajes (idchat, visto, mensaje)  values (@chat,@visto,@mensaje)");
            cmdd.Parameters.Add("@visto", SqlDbType.Int).Value = 0;
            cmdd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = "En breve estaremos en contacto con usted, agradeceremos su paciencia";
            cmdd.Parameters.Add("@chat", SqlDbType.VarChar).Value = recibe;
            cmdd.CommandType = CommandType.Text;

            return EjecutarComando(cmdd);
        }

        public int Mensajesenviados(UsuarioBO objeus)
        {
            SqlCommand cmd = new SqlCommand("insert into mensaje(visto, mensaje, idchat) values (@visto, @mensaje, @idchat)");
            cmd.Parameters.Add("@visto", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@mensaje", SqlDbType.VarChar).Value = objeus.mensaje;
            cmd.Parameters.Add("@idchat", SqlDbType.Int).Value = objeus.idchat;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }


        public DataTable usersnotifica(UsuarioBO obelogin)
        {
            String comandoSQL = string.Format("select u.idusuario, u.email, u.idusuario as ID, u.nombre, u.foto   from usuario u, chat c   where c.idenvia <> {0} and u.idusuario = c.idenvia and c.idrecibe ={0} and u.visto=0", obelogin.id);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoSQL, establecerConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }




    }
}