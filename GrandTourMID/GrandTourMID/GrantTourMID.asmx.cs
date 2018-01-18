using GrandTourMID.BO;
using GrandTourMID.DAO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace GrandTourMID
{
    /// <summary>
    /// Descripción breve de GrantTourMID
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GrantTourMID : System.Web.Services.WebService
    {

        LugarDAO BDLU = new LugarDAO();
        LoginDAO BDLO = new LoginDAO();
        UsuarioBO objeus = new UsuarioBO();
        UsuarioDAO BDUS = new UsuarioDAO();
        PublicacionDAO BDPU = new PublicacionDAO();
        CorreoBO objeco = new CorreoBO();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Cargarlugares()
        {
            DataTable DTLU = BDLU.CargarLugares();
            string SalidaJSON = string.Empty;
            SalidaJSON = JsonConvert.SerializeObject(DTLU);

            // Salida en el WebService 
            HttpContext Contexto = HttpContext.Current;
            Contexto.Response.ContentType = "application/json";
            Contexto.Response.Write(SalidaJSON);
            Contexto.Response.End();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void RegistrarUsuario(string nombre, string apellidopa, string apellidoma, string pas, string us, string correo)
        {
            string respuesta = "";
            objeus.email = correo;
            objeus.usuario = us;
            DataTable usre = BDUS.ValidarRegistroUsuario(objeus);
            DataTable usemail = BDUS.ValidarRegistroEmail(objeus);

            if (usre.Rows.Count > 0)
            {
                respuesta = "2";
            }
            else if (usemail.Rows.Count > 0)
            {
                respuesta = "3";
            }
            else
            {
                objeus.nombre = nombre;
                objeus.apellidop = apellidopa;
                objeus.apellidom = apellidopa;
                objeus.contraseña = pas;
                BDUS.Agregar(objeus);
                respuesta = "1";
            }

            HttpContext Contexto = HttpContext.Current;
            Contexto.Response.Write(respuesta);

        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CargarPublicaciones()
        {
            DataTable dtspu = BDPU.CargarPublicaciones();
            string SalidaJson = String.Empty;
            SalidaJson = JsonConvert.SerializeObject(dtspu);
            HttpContext Contexto = HttpContext.Current;
            Contexto.Response.ContentType = "application/json";
            Contexto.Response.Write(SalidaJson);
            Contexto.Response.End();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void IniciarSesion(string us, string contra)
        {
            objeus.usuario = us;
            objeus.contraseña = contra;
            ArrayList datos = BDLO.Login(objeus);
            if (datos.Count > 0)
            {
                string respuesta = "";
                int idtipos = Convert.ToInt32(datos[2]);
                if (idtipos == 2)
                {
                    int ID = Convert.ToInt32(datos[0].ToString());
                    DataTable dts = BDUS.BuscarUser(ID);
                    respuesta = JsonConvert.SerializeObject(dts);
                    HttpContext Contexto = HttpContext.Current;
                    Contexto.Response.ContentType = "application/json";
                    Contexto.Response.Write(respuesta);
                    Contexto.Response.End();
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarCodigo(string correo)
        {
            GenerarCodigo(objeco);
            objeco.email = correo;
            BDUS.ActualizarCodigo(objeco);
            HttpContext Contexto = HttpContext.Current;
            Context.Response.Write(objeco.codigo);

        }






        private string GenerarCodigo(CorreoBO objec)
        {
            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 5;
            string nuevacadena = "";

            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }
            objec.codigo = nuevacadena;
            return nuevacadena;
        }
    }
}

