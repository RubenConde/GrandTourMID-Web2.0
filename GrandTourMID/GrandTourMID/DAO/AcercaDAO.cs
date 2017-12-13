using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class AcercaDAO:ConexionSQL
    {
        SqlCommand cmd;


        public int ActualizarAcercaDe(AcercaBO objeace)
        {
            cmd = new SqlCommand("update Acercade set titulo=@titulo, subtitulo=@subtitulo, infoapp=@infoapp, infoadicional=@infoadicional, img=@img");
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = objeace.titulo;
            cmd.Parameters.Add("@subtitulo", SqlDbType.VarChar).Value = objeace.subtitulo;
            cmd.Parameters.Add("@infoapp", SqlDbType.VarChar).Value = objeace.infoapp;
            cmd.Parameters.Add("@infoadicional", SqlDbType.VarChar).Value = objeace.infoAdicional;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }







    }
}