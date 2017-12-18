using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class InicioDAO:ConexionSQL
    {
        SqlCommand cmd;


        public int ActualizarTitulo1(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulo=@titulo where idacerca=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int ActualizarTitulo3(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulo3=@titulo where idacerca=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo3;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarTitulo4(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulo4=@titulo where idacerca=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo2;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarAcercade(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulo2=@titulo, subtitulo=@sub, infoapp=@infoa, infoadicional=@infoad where idacerca=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo;
            cmd.Parameters.Add("@sub", SqlDbType.VarChar).Value = objei.subtitulo;
            cmd.Parameters.Add("@infoa", SqlDbType.VarChar).Value = objei.infoapp;
            cmd.Parameters.Add("@infoad", SqlDbType.VarChar).Value = objei.infoAdicional;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int Actualizarimagen1(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set img=@img where idacerca=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }

        public DataTable CargarInfoInicio()
        {
            string sql = string.Format("select * from [Acercade]");
            return EjercutarSentenciaBusqueda(sql);
        }





    }
}