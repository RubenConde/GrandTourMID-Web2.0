﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrandTourMID.DAO
{
    public class ConexionSQL
    {
        SqlCommand ComandoSQL;
        SqlDataAdapter adaptador;
        DataSet DataSetAdaptador;
        SqlConnection con;
        SqlCommand exec;

        //"Data Source=SQL5037.site4now.net;Initial Catalog=DB_A33427_tour;User Id=DB_A33427_tour_admin;Password=pelana182;"
        //"Server=localhost;Database=DB_A33427_tour;Trusted_Connection=True;"
        public ConexionSQL()
        {
            con = new SqlConnection("Data Source=SQL5037.site4now.net;Initial Catalog=DB_A33427_tour;User Id=DB_A33427_tour_admin;Password=pelana182;");
            //sirve para establecer las consultas e instrucciones SQL que se ejecutarán en el servidor
            exec = new SqlCommand();
        }
        public SqlConnection establecerConexion()
        {
            string cs = "Data Source=SQL5037.site4now.net;Initial Catalog=DB_A33427_tour;User Id=DB_A33427_tour_admin;Password=pelana182;";
            con = new SqlConnection(cs);
            return con;
        }
        public SqlConnection establecerConexion(string conexionstring)
        {
            string cs = conexionstring;
            con = new SqlConnection(cs);
            return con;
        }
        public void abrirConexion()
        {
            con.Open();
        }
        public void cerrarconexion()
        {
            con.Close();
        }
        public int EjecutarComando(SqlCommand sqlcomando)
        {
            // INSERT, DELETE, UPDATE
            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            int id = 0;
            id = Convert.ToInt32(ComandoSQL.ExecuteScalar());
            return (id != 0) ? id : 0; ;
        }
        public DataSet EjecutarSentencia(SqlCommand sqlcomando)
        {
            // SELECT
            ComandoSQL = new SqlCommand();
            adaptador = new SqlDataAdapter();
            DataSetAdaptador = new DataSet();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            adaptador.SelectCommand = ComandoSQL;
            adaptador.Fill(DataSetAdaptador);
            this.cerrarconexion();
            return DataSetAdaptador;
        }
        public DataTable EjercutarSentenciaBusqueda(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable tabla = new DataTable();
            //rellenar un objeto DataSet con los resultados del elemento SelectCommand
            adapter.Fill(tabla);
            return tabla;
        }

        public string EjectuadorComandosDatoEspecifico(string ComandSQL, string Columna)
        {
            SqlCommand cmd = new SqlCommand(ComandSQL, this.establecerConexion());
            this.abrirConexion();
            SqlDataReader LeerDato;
            LeerDato = cmd.ExecuteReader();
            LeerDato.Read();
            string DatoEspecifico = LeerDato[Columna].ToString();
            LeerDato.Close();
            this.cerrarconexion();
            return DatoEspecifico;
        }

    }
}