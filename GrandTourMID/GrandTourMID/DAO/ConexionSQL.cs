using System;
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

        public ConexionSQL()
        {
            con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=proyectoTour;Trusted_Connection=True;");
            //sirve para establecer las consultas e instrucciones SQL que se ejecutarán en el servidor
            exec = new SqlCommand();
        }
        public SqlConnection establecerConexion()
        {
            string cs = "Server=localhost\\SQLEXPRESS;Database=proyectoTour;Trusted_Connection=True;";
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
    }
}