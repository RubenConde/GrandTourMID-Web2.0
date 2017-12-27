using GrandTourMID.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class LugarDAO:ConexionSQL
    {
        SqlCommand cmd;
        public int AgregarLugar(LugarBO objelug)
        {
            cmd = new SqlCommand("insert into lugares  (fechafundacion, nombre, informacionapp, informacionweb, latitud, longitud, direccion, imagenportada, direccionmap) values (@fecha, @nombre, @infoapp, @infoweb, @latitud, @longitud, @direccion, @img, @direccionmap)");
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = objelug.fecha;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoapp", SqlDbType.VarChar).Value = objelug.informacionapp;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = objelug.latitud;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = objelug.longitud;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objelug.imagen;
            cmd.Parameters.Add("@direccionmap", SqlDbType.VarChar).Value = objelug.direccionmaps;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public DataTable CargarLugares()
        {
            string sql = string.Format("select * from lugares");
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable BuscarLugar(int id)
        {
            string sql = string.Format("select nombre, fechafundacion, informacionapp, informacionweb, latitud, longitud, direccion, direccionmap, idlugar, imagenportada from lugares where idlugar={0}", id);
            return EjercutarSentenciaBusqueda(sql);

        }














    }
}