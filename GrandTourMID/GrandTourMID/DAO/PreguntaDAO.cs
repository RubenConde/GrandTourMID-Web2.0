using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class PreguntaDAO:ConexionSQL
    {
        SqlCommand cmd;

        public int AgregarPregunta(PreguntasBO objep)
        {
            cmd = new SqlCommand("insert into pregunta (pregunta, idlugar) output inserted.idpregunta values (@pregunta, @idlugar)");
            cmd.Parameters.Add("@pregunta", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@idlugar", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            int idpregunta = EjecutarComando(cmd);
            cmd = new SqlCommand("insert into Respuestas (correcta, respuesta2, respuesta3, respuesta4, idpregunta)values(@correcta, @re2, @re3, @re4, @id)");
            cmd.Parameters.Add("@correcta", SqlDbType.VarChar).Value = objep.correcta;
            cmd.Parameters.Add("@re2", SqlDbType.VarChar).Value = objep.respuesta2;
            cmd.Parameters.Add("@re3", SqlDbType.VarChar).Value = objep.respuesta3;
            cmd.Parameters.Add("@re4", SqlDbType.VarChar).Value = objep.respuesta4;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = idpregunta;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


        public DataTable VerPreguntasLugar(int id)
        {
            string sql = string.Format("select pregunta.idpregunta, pregunta.pregunta, Respuestas.correcta, Respuestas.respuesta2, Respuestas.respuesta3, Respuestas.respuesta4 from pregunta, Respuestas, lugares where pregunta.idpregunta = Respuestas.idpregunta and pregunta.idlugar = lugares.idlugar and lugares.idlugar = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable verinfopregunta(int id)
        {
            string sql = string.Format("select pregunta.idpregunta, lugares.imagenportada, pregunta.pregunta, Respuestas.correcta, Respuestas.respuesta2, Respuestas.respuesta3,lugares.nombre, Respuestas.respuesta4 from pregunta, Respuestas, lugares where pregunta.idpregunta = Respuestas.idpregunta and pregunta.idlugar = lugares.idlugar and pregunta.idpregunta ='{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }
        public int ActualizarPregunta(PreguntasBO objep)
        {
            cmd = new SqlCommand("update pregunta set pregunta=@pre where idpregunta=@id");
            cmd.Parameters.Add("@pre", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            int id = EjecutarComando(cmd);
            cmd = new SqlCommand("update Respuestas set correcta=@correcta, respuesta2=@re2, respuesta3=@re3, respuesta4=@re4 where idpregunta=@id");
            cmd.Parameters.Add("@correcta", SqlDbType.VarChar).Value = objep.correcta;
            cmd.Parameters.Add("@re2", SqlDbType.VarChar).Value = objep.respuesta2;
            cmd.Parameters.Add("@re3", SqlDbType.VarChar).Value = objep.respuesta3;
            cmd.Parameters.Add("@re4", SqlDbType.VarChar).Value = objep.respuesta4;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


    }
}