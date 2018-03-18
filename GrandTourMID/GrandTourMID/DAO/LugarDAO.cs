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
            cmd = new SqlCommand("insert into lugares  (fechafundacion, nombre, informacionapp, informacionweb, latitud, longitud, direccion, imagenportada, direccionmap, icono, rutaicono) values (@fecha, @nombre, @infoapp, @infoweb, @latitud, @longitud, @direccion, @img, @direccionmap, @icono, @rutaicono)");
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = objelug.fecha;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoapp", SqlDbType.VarChar).Value = objelug.informacionapp;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = objelug.latitud;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = objelug.longitud;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objelug.imagen;
            cmd.Parameters.Add("@direccionmap", SqlDbType.VarChar).Value = objelug.direccionmaps;
            cmd.Parameters.Add("@icono", SqlDbType.Image).Value = objelug.icono;
            cmd.Parameters.Add("@rutaicono", SqlDbType.VarChar).Value = objelug.rutaicono;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int AgregarSucursal(LugarBO objelug)
        {
            cmd = new SqlCommand("insert into lugares  (nombre, informacionweb, latitud, longitud, direccion, imagenportada, direccionmap, idtipo, icono, rutaicono) values (@nombre, @infoweb, @latitud, @longitud, @direccion, @img, @direccionmap, @idtipo, @icono, @rutaicono)");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@latitud", SqlDbType.VarChar).Value = objelug.latitud;
            cmd.Parameters.Add("@longitud", SqlDbType.VarChar).Value = objelug.longitud;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@img", SqlDbType.VarChar).Value = objelug.imagen;
            cmd.Parameters.Add("@direccionmap", SqlDbType.VarChar).Value = objelug.direccionmaps;
            cmd.Parameters.Add("@idtipo", SqlDbType.Int).Value = objelug.idtipo;
            cmd.Parameters.Add("@icono", SqlDbType.Image).Value = objelug.icono;
            cmd.Parameters.Add("@rutaicono", SqlDbType.VarChar).Value = objelug.rutaicono;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public string GetUltimoLugar()
        {
            string columna = "idlugar";
            string sql = string.Format("select top(1) idlugar from lugares order by idlugar desc");

            return EjectuadorComandosDatoEspecifico(sql, columna);
        }
        public int AgregarEnSucursal(int iduser, int idlugar)
        {
            cmd = new SqlCommand("insert into sucursal (idusuario, idlugar) values (@idusuario, @idlugar)");
            cmd.Parameters.Add("@idusuario", SqlDbType.VarChar).Value = iduser;
            cmd.Parameters.Add("@idlugar", SqlDbType.VarChar).Value = idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public DataTable CargarLugares()
        {
            string sql = string.Format("select * from lugares where idtipo = 1");
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable CargarSucursales(int iduser)
        {
            string sql = string.Format("Select * from lugares l join sucursal s on s.idlugar = l.idlugar join usuario u on u.idusuario = s.idusuario where s.idusuario = '{0}'", iduser);
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable CargarSucursal(int idlugar)
        {
            string sql = string.Format("Select * from lugares where idlugar = '{0}'", idlugar);
            return EjercutarSentenciaBusqueda(sql);

        }


        public DataTable BuscarLugar(int id)
        {
            string sql = string.Format("select nombre, CONVERT(varchar, fechafundacion, 107) as fechafundacion, informacionapp, informacionweb, latitud, longitud, direccion, direccionmap, idlugar, imagenportada, rutaicono from lugares where idlugar={0}", id);
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable BuscarLugarPorUsuario(int id)
        {
            string sql = string.Format("select l.nombre, l.idlugar, l.imagenportada from Visita v join lugares l on v.idlugar = l.idlugar join usuario u on v.idusuario = u.idusuario where v.idusuario = {0}", id);
            return EjercutarSentenciaBusqueda(sql);

        }
        public DataTable CargarUltimasFotosUser(int id)
        {
            string sql = string.Format("select top 6 f.foto, f.idfoto from UsuarioFotos uf join usuario u on u.idusuario = uf.idusuario join Fotos f on f.idfoto = uf.idfoto where u.idusuario = {0} order by f.idfoto desc", id);
            return EjercutarSentenciaBusqueda(sql);

        }

        public DataTable CargarFotosLugarUsuario(int idlugar, int idusuario)
        {
            string sql = string.Format("select f.idfoto, f.foto from UsuarioFotos uf join fotos f on f.idfoto = uf.idfoto join usuario u on u.idusuario = uf.idusuario join lugares l on l.idlugar = uf.idlugar where uf.idusuario = {0} and uf.idlugar = {1} ", idusuario, idlugar);
            return EjercutarSentenciaBusqueda(sql);

        }


        public int ActualizarImagenLugar(LugarBO objelu)
        {
            cmd = new SqlCommand("update lugares set imagenportada=@imagen where idlugar=@id");
            cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value= objelu.imagen;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objelu.idlugar;
            

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);

        }

        public int ActualizarDatosLugar(LugarBO objelug)
        {
            cmd = new SqlCommand("update lugares set fechafundacion=@fecha, nombre=@nombre,informacionapp=@infoapp, informacionweb=@infoweb, direccion=@direccion, icono=@icono, rutaicono=@rutaicono where idlugar=@id ");
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = objelug.fecha;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoapp", SqlDbType.VarChar).Value = objelug.informacionapp;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objelug.idlugar;
            cmd.Parameters.Add("@icono", SqlDbType.Image).Value = objelug.icono;
            cmd.Parameters.Add("@rutaicono", SqlDbType.VarChar).Value = objelug.rutaicono;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarDatosSucursal(LugarBO objelug)
        {
            cmd = new SqlCommand("update lugares set nombre=@nombre, informacionweb=@infoweb, direccion=@direccion, icono=@icono, rutaicono=@rutaicono where idlugar=@id ");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objelug.idlugar;
            cmd.Parameters.Add("@icono", SqlDbType.Image).Value = objelug.icono;
            cmd.Parameters.Add("@rutaicono", SqlDbType.VarChar).Value = objelug.rutaicono;

            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }
        public int ActualizarDatosSucursalsinicono(LugarBO objelug)
        {
            cmd = new SqlCommand("update lugares set nombre=@nombre, informacionweb=@infoweb, direccion=@direccion where idlugar=@id ");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = objelug.nombre;
            cmd.Parameters.Add("@infoweb", SqlDbType.VarChar).Value = objelug.informacionweb;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = objelug.direccion;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objelug.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }

        public int ActualizarUbicacionLugar(LugarBO objelug)
        {
            cmd = new SqlCommand("update lugares set latitud=@la, longitud=@lon, direccionmap=@diremap where idlugar=@id");
            cmd.Parameters.Add("@la", SqlDbType.VarChar).Value = objelug.latitud;
            cmd.Parameters.Add("@lon", SqlDbType.VarChar).Value = objelug.longitud;
            cmd.Parameters.Add("@diremap", SqlDbType.VarChar).Value = objelug.direccionmaps;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objelug.idlugar;
            cmd.CommandType = CommandType.Text;
            return EjecutarComando(cmd);
        }








    }
}