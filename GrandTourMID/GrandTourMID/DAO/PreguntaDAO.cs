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
            cmd = new SqlCommand("insert into Respuesta (textorespuesta, pregunta, textoincorrecta, textoincorrecta2, textoincorrecta3, idlugar)values(@textorespuesta, @pregunta, @textoincorrecta, @textoincorrecta2, @textoincorrecta3, @idlugar)");
            cmd.Parameters.Add("@textorespuesta", SqlDbType.VarChar).Value = objep.correcta;
            cmd.Parameters.Add("@pregunta", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@textoincorrecta", SqlDbType.VarChar).Value = objep.respuesta2;
            cmd.Parameters.Add("@textoincorrecta2", SqlDbType.VarChar).Value = objep.respuesta3;
            cmd.Parameters.Add("@textoincorrecta3", SqlDbType.VarChar).Value = objep.respuesta4;
            cmd.Parameters.Add("@idlugar", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


        public DataTable VerPreguntasLugar(int id)
        {
            string sql = string.Format("select r.idrespuesta, r.pregunta, r.textorespuesta, r.textoincorrecta, r.textoincorrecta2, r.textoincorrecta3 from respuesta r where r.idlugar =  '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }
        public DataTable VerRetosLugar(int id)
        {
            string sql = string.Format("select reto.idreto, reto.reto from reto, lugares where reto.idlugar = lugares.idlugar and lugares.idlugar = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }

        public DataTable verinfopregunta(int id)
        {
            string sql = string.Format("  select r.idrespuesta, r.pregunta, r.textorespuesta, r.textoincorrecta, r.textoincorrecta2, r.textoincorrecta3, l.imagenportada, l.nombre from respuesta r join lugares l on l.idlugar = r.idlugar where r.idrespuesta = '{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }
        public DataTable verinforeto(int id)
        {
            string sql = string.Format("select reto.idreto, lugares.imagenportada, reto.reto, lugares.nombre from reto, lugares where reto.idlugar = lugares.idlugar and reto.idreto ='{0}'", id);
            return EjercutarSentenciaBusqueda(sql);
        }
        public int ActualizarPregunta(PreguntasBO objep)
        {

            cmd = new SqlCommand("update Respuesta set pregunta=@pregunta, textorespuesta=@correcta, textoincorrecta=@re2, textoincorrecta2=@re3, textoincorrecta3=@re4 where idrespuesta=@id");
            cmd.Parameters.Add("@correcta", SqlDbType.VarChar).Value = objep.correcta;
            cmd.Parameters.Add("@re2", SqlDbType.VarChar).Value = objep.respuesta2;
            cmd.Parameters.Add("@re3", SqlDbType.VarChar).Value = objep.respuesta3;
            cmd.Parameters.Add("@re4", SqlDbType.VarChar).Value = objep.respuesta4;
            cmd.Parameters.Add("@pregunta", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int ActualizarReto(PreguntasBO objep)
        {
            cmd = new SqlCommand("update reto set reto=@pre where idpregunta=@id");
            cmd.Parameters.Add("@pre", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int AgregarReto(PreguntasBO objep)
        {
            cmd = new SqlCommand("insert into reto (reto, idlugar) values (@reto, @idlugar)");
            cmd.Parameters.Add("@reto", SqlDbType.VarChar).Value = objep.pregunta;
            cmd.Parameters.Add("@idlugar", SqlDbType.Int).Value = objep.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }


    }
}