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
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo4;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarAcercade(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulo2=@titulo,infoapp=@infoa where idacerca=1");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objei.titulo;
            cmd.Parameters.Add("@infoa", SqlDbType.VarChar).Value = objei.infoapp;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int Actualizarimagen1(InicioBO objei)
        {
            cmd = new SqlCommand("update imagenesinicio set img=@img where idimg=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int Actualizarimagen2(InicioBO objei)
        {
            cmd = new SqlCommand("update imagenesinicio set img1=@img where idimg=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int Actualizarimagenheader1(InicioBO objei)
        {
            cmd = new SqlCommand("update imagenesinicio set header1=@img where idimg=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int Actualizarimagenparallax(InicioBO objei)
        {
            cmd = new SqlCommand("update imagenesinicio set header2=@img where idimg=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int Actualizarimagenparallax2(InicioBO objei)
        {
            cmd = new SqlCommand("update imagenesinicio set header3=@img where idimg=1");
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objei.img;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public DataTable CargarImgsInicio()
        {            
            string sql = string.Format("select * from imagenesinicio");
            return EjercutarSentenciaBusqueda(sql);
        }


        public DataTable CargarInfoInicio()
        {
            string sql = string.Format("select * from [Acercade]");
            return EjercutarSentenciaBusqueda(sql);
        }

        public int ActualizarInfojugar(InicioBO objei)
        {
            cmd = new SqlCommand("update Acercade set titulojugar=@tit, subtitulojugar=@sub where idacerca=1");
            cmd.Parameters.Add("@tit", SqlDbType.VarChar).Value = objei.titulo;
            cmd.Parameters.Add("@sub", SqlDbType.VarChar).Value = objei.subtitulo;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }



    }
}