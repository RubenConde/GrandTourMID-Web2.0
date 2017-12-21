using GrandTourMID.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class LoginDAO:ConexionSQL
    {

        public ArrayList Login(UsuarioBO objeus)
        {
            string comando = string.Format("SELECT usuario.idusuario, usuario.nombre, usuario.idtipo, usuario.foto, tipo.nombre as rol, usuario.estado FROM usuario, tipo  WHERE usuario = '{0}' and contrasenia = '{1}' and estado = 1 and usuario.idtipo = tipo.idtipo", objeus.usuario, objeus.EncriptarMD5(objeus.contraseña));
            SqlCommand adapter = new SqlCommand(comando, establecerConexion());
            abrirConexion();
            SqlDataReader lectura;
            ArrayList tipous = new ArrayList();
            lectura = adapter.ExecuteReader();
            while (lectura.Read())
            {
                tipous.Add(lectura["idusuario"].ToString());
                tipous.Add(lectura["nombre"].ToString());
                tipous.Add(lectura["idtipo"].ToString());
                tipous.Add(lectura["foto"].ToString());
                tipous.Add(lectura["rol"].ToString());
                tipous.Add(lectura["estado"].ToString());

            }
            cerrarconexion();
            return tipous;

        }

    }
}