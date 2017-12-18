using GrandTourMID.BO;
using GrandTourMID.DAO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GrandTourMID.Controllers
{
    public class AjaxController : Controller
    {
        UsuarioBO objeus = new UsuarioBO();
        LoginDAO BDL = new LoginDAO();
        UsuarioDAO BDU = new UsuarioDAO();
        CorreoBO objec = new CorreoBO();
        ContactoBO objecontacto = new ContactoBO();
        ContactoDAO BDCO = new ContactoDAO();
        PublicacionDAO BDP = new PublicacionDAO();
        ChatDAO BDCH = new ChatDAO();
        InicioBO objei = new InicioBO();
        InicioDAO BDI = new InicioDAO();
        // GET: Ajax
        public ActionResult Ajax(String data, UsuarioBO objeus)
        {
            string respuesta = "";
            //Login
            if (data == "login")
            {
                objeus.usuario = Request.Form["user"];
                objeus.contraseña = Request.Form["psw"];

                ArrayList datos = BDL.Login(objeus);
                if (datos.Count > 0)
                {
                    Session["ID"] = datos[0].ToString();
                    Session["idtipo"] = datos[2].ToString();
                    Session["imagen"] = datos[3].ToString();
                    Session["rol"] = datos[4].ToString();
                    Session["estado"] = datos[5].ToString();
                    respuesta = "1";
                }
                else
                {
                    respuesta = "0";
                }

            }
            //Recuperando datos en el perfil de usuario
            else if (data == "DatosUsuario")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                int id = objeus.id;
                DataTable dt = BDU.BuscarUser(id);
                String jSonString = ConvertirDataJson(dt);
                respuesta = jSonString;
                // string JSONresult;
                //JSONresult = JsonConvert.SerializeObject(dt);
                // Response.Write(JSONresult);
                respuesta = jSonString;


                //  respuesta = "{\"nombre\" : \"" + objeus.nombre + " \",\"foto\" : \"" + "/img/" + objeus.imagen + "\"}";

            }
            //Agregar Registro
            else if (data == "registro")
            {
                try
                {

                    objeus.nombre = Request.Form["nomc"];
                    objeus.apellidop = Request.Form["apep"];
                    objeus.apellidom = Request.Form["apem"];
                    objeus.contraseña = Request.Form["ps"];
                    objeus.email = Request.Form["coe"];
                    objeus.usuario = Request.Form["usr"];
                    BDU.Agregar(objeus);
                    respuesta = "1";
                }
                catch
                {
                    respuesta = "0";
                }

            }

            //Validar Contraseña en el perfil de usuario
            else if (data == "checkpass")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                int id = objeus.id;
                objeus.contraseña = Request.Form["passprofilevalidar"];
                string validar = objeus.EncriptarMD5(Request.Form["passprofilevalidar"]);
                string contra = "";
                ArrayList datos = BDU.ValidarContraseña(objeus);
                if (datos.Count > 0)
                {
                    contra = datos[0].ToString();
                }
                if (validar == contra)
                {
                    respuesta = "1";
                }
                else
                {
                    respuesta = "0";
                }


            }
            //Mostrar Usuarios activos
            else if (data == "ListadoUsuarios")
            {

                DataTable listaus = BDU.BuscarUsuarioActivo();
                foreach (DataRow row in listaus.Rows)
                {

                    respuesta = "<li class=\"w3-bar\"><img src=\"" + row["Foto"] + "\" class=\"w3-bar-item w3-circle w3-hide-small\" style=\"width:85px\"><div class=\"w3-bar-item\"><span class=\"w3-large\">" + row["Nombre"] + "</span><br><span>" + row["Usuario"] + "</span></div><br /><button class=\"w3-round w3-button w3-green w3-small\">Activo</button>  <button id=\"btnaccountdesact\" class=\"w3-round w3-button w3-green w3-small\" onclick=\"desact(" + row["ID"] + ")\">Desactivar</button><button onclick=\"VerInfo(" + row["ID"] + ")\" class=\"fa fa-external-link w3-bar-item w3-button w3-white w3-xlarge w3-right editar\"></button></li>";

                    Response.Write(respuesta);
                }

                respuesta = "";
            }
            //usuarios inactivos
            else if (data == "ListadoUsuariosInactivos")
            {

                DataTable listaus = BDU.BuscarUsuarioInactivo();
                foreach (DataRow row in listaus.Rows)
                {

                    respuesta = "<li class=\"w3-bar\"> <a href=\"" + row["idusuario"] + "\" class=\"fa fa-external-link w3-bar-item w3-button w3-white w3-xlarge w3-right editar\"></a>" +
                        "<img src=/img/" + row["foto"] + " class=\"w3-bar-item w3-circle w3-hide-small\" style=\"width:85px\"> " +
                        "<div class=\"w3-bar-item\"> <span class=\"w3-large\">" + row["nombreus"] +
                        "</span><br> <span>" + row["usuario"] + "</span></div></li><br/>";

                    Response.Write(respuesta);
                }

                respuesta = "";
            }
            //usuarios bloqueados
            else if (data == "ListadoUsuariosBloqueados")
            {

                DataTable listaus = BDU.BuscarUsuarioBloqueado();

                foreach (DataRow row in listaus.Rows)
                {

                    respuesta = "<li class=\"w3-bar\"> <a href=\"" + row["idusuario"] + "\" class=\"fa fa-external-link w3-bar-item w3-button w3-white w3-xlarge w3-right editar\"></a>" +
                        "<img src=" + row["foto"] + " class=\"w3-bar-item w3-circle w3-hide-small\" style=\"width:85px\"> " +
                        "<div class=\"w3-bar-item\"> <span class=\"w3-large\">" + row["nombreus"] +
                        "</span><br> <span>" + row["usuario"] + "</span></div></li><br/>";
                    Response.Write(respuesta);
                }

                respuesta = "";
            }
            //enviar correo electronico
            else if (data == "code")
            {
                try
                {
                    int estado;
                    objec.email = Request.Form["ema"];
                    ArrayList datos = BDU.TipoDeEstado(objec);
                    if (datos.Count > 0)
                    {
                        Session["estado"] = datos[0].ToString();
                    }

                    estado = Convert.ToInt32(Session["estado"]);

                    if (estado == 1)
                    {


                        GenerarCodigo(objec);
                        objec.email = Request.Form["ema"];
                        BDU.ActualizarCodigo(objec);
                        objec.para = Request.Form["ema"];
                        objec.asunto = "<label class=\"w3-text-teal\">Codigo de Verificación</label>";
                        MailMessage correo = new MailMessage();
                        correo.From = new MailAddress("soportegrandtourmid@gmail.com");
                        correo.To.Add(objec.para);
                        correo.Subject = objec.asunto;
                        correo.Body = "Este código te servira para recuperar tu cuenta:\n\n" + objec.codigo + "\n\nSi tu no solicitaste este código, hacer caso omiso al mensaje.\n" + "Este mensaje es enviado de manera automática, favor de no responder.\n\n" + "-Equipo de soporte de Grand Tour MID";
                        correo.IsBodyHtml = false;
                        correo.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = ("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string cuenta = "soportegrandtourmid@gmail.com";
                        string contra = "peluso182";
                        smtp.Credentials = new System.Net.NetworkCredential(cuenta, contra);
                        smtp.Send(correo);
                        respuesta = "1";
                    }
                    else if (estado == 2)
                    {
                        GenerarCodigo(objec);
                        objec.email = Request.Form["ema"];
                        BDU.ActualizarCodigo(objec);
                        objec.para = Request.Form["ema"];
                        objec.asunto = "Cuenta bloqueada";
                        MailMessage correo = new MailMessage();
                        correo.From = new MailAddress("soportegrandtourmid@gmail.com");
                        correo.To.Add(objec.para);
                        correo.Subject = objec.asunto;
                        correo.Body = "Lamentablemente tu cuenta se encuentra bloqueada, y no es posible recuperarla lamentamos la situación";
                        correo.IsBodyHtml = false;
                        correo.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = ("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string cuenta = "soportegrandtourmid@gmail.com";
                        string contra = "peluso182";
                        smtp.Credentials = new System.Net.NetworkCredential(cuenta, contra);
                        smtp.Send(correo);


                    }

                }
                catch
                {
                    respuesta = "0";
                }



            }
            //validar codigo de verificación
            else if (data == "CodeRecovery")
            {
                objec.codigo = Request.Form["cod"];
                ArrayList dcode = BDU.ValidarCodigo(objec);
                if (dcode.Count > 0)
                {
                    Session["ID"] = dcode[0].ToString();
                    respuesta = "1";
                }
                else
                {
                    respuesta = "0";
                }


            }

            //Cambiar contraseña
            else if (data == "Changepassword")
            {
                try
                {
                    objeus.id = Convert.ToInt32(Session["ID"]);
                    objeus.contraseña = Request.Form["pass1"];
                    respuesta = "1";
                }
                catch
                {
                    respuesta = "0";
                }



            }
            //cargar informacion del apartado de contacto en el backend
            else if (data == "cargarInfoContact")
            {

                DataTable dt = BDCO.CargarInfoContacto();
                String jSonString = ConvertirDataJson(dt);

                respuesta = jSonString;

            }

            //cargar informacion del apartado de contacto en el Index
            else if (data == "InfoContactoIndex")
            {

                DataTable dtc = BDCO.CargarInfoContacto();
                String jSonString = ConvertirDataJson(dtc);
                respuesta = jSonString;

            }

            //actualizar la informacion del apartado de contacto en el backend
            else if (data == "InsertInfoContact")
            {

                try
                {
                    objecontacto.titulo = Request.Form["tit"];
                    objecontacto.subtitulo = Request.Form["subt"];
                    objecontacto.direccion = Request.Form["dire"];
                    objecontacto.numero = Request.Form["tel"];
                    objecontacto.correo = Request.Form["corr"];
                    objecontacto.mensaje = Request.Form["mensajecontacto"];
                    objecontacto.lat = Request.Form["la"];
                    objecontacto.lon = Request.Form["lon"];
                    BDCO.AgregarInfoContacto(objecontacto);
                    respuesta = "1";
                }
                catch { respuesta = "0"; }

            }

            //enviar un mensaje de contacto desde el index
            else if (data == "EnviarMensajeContacto")
            {
                try
                {
                    objecontacto.nombre = Request.Form["nomcontacto"];
                    objecontacto.correo = Request.Form["correocontacto"];
                    objecontacto.mensaje = Request.Form["mensajecontacto"];
                    BDCO.MensajeDeContacto(objecontacto);

                    respuesta = "1";
                }
                catch { respuesta = "0"; }

            }


            //mostrar mensajes recibidos no vistos
            else if (data == "InboxRecibidos")
            {
                DataTable listainbox = BDCO.InboxRecibidos();
                foreach (DataRow row in listainbox.Rows)
                {
                    respuesta = "<a onclick=\"VerMensa(" + row["idmensaje"] + ",'" + row["nombre"] + "'); w3_close();\" class=\"w3-bar-item w3-button w3-border-bottom test w3-hover-light-grey\" id=\"firstTab\"><div class=\"w3-container\"><img class=\"w3-round w3-margin-right\" src=\"/img/usuario.png\" style=\"width:15%;\"><span class=\"w3-opacity w3-large\">" + row["nombre"] + "</span><h6></h6><p>" + row["email"] + "</p></div></a>";

                    Response.Write(respuesta);

                }
                respuesta = "";
            }
            //Número de notificaciones sin leer mensajes recibidos
            else if (data == "Inboxnotifica")
            {
                DataTable listanotiinbox = BDCO.NumeroInbox();
                foreach (DataRow row in listanotiinbox.Rows)
                {
                    respuesta = "<a id=\"myBtn\" onclick=\"myFunc('ContenedorUsuario')\" href=\"javascript: void(0)\" class=\"w3-bar-item w3-teal w3-button\"><i class=\"fa fa-inbox w3-margin-right\"></i>Mensajes(" + row["mensaje"] + ")<i class=\"fa fa-caret-down w3-margin-left\"></i></a>";

                    Response.Write(respuesta);
                }
                respuesta = "";
            }

            ///ver el mensaje cuando se selecciona a un usuario
            else if (data == "Verinbocs")
            {
                objecontacto.idcontacto = Convert.ToInt32(Request.QueryString["idmensajecontac"]);
                DataTable vermen = BDCO.Vermensaje(objecontacto);
                foreach (DataRow row in vermen.Rows)
                {
                    respuesta = "<br><img class=\"w3-round  w3-animate-top\" src=\"/img/usuario.png\" style=\"width:20%;\"><h5 id=\"correoresponder\" class=\"w3-opacity\">" + row["email"] + "</h5><h4><i class=\"fa fa-clock-o\">" + row["fecha"] + "</i></h4><a class=\"w3-button w3-light-grey\" id=\"btnresponder\" onclick=\" Correo(); document.getElementById('id01').style.display='block';\">Responder<i class=\"w3-margin-left fa fa-mail-reply\"></i></a><hr><p>" + row["mensaje"] + "</p><p>Atte: <br>" + row["nombre"] + "</p><input name=\"CorreoOculto\" id=\"CorreoOculto\" value=\"" + row["email"] + "\" type=\"hidden\"/>";

                    Response.Write(respuesta);
                }

                BDCO.MensajeLeido(objecontacto);

                respuesta = "";

            }

            //notificaciones de mensajes ya leidos contador
            else if (data == "Inboxnotificaleidos")
            {
                DataTable listanotiinbox = BDCO.NumeroInboxLeido();
                foreach (DataRow row in listanotiinbox.Rows)
                {
                    respuesta = "<a id=\"myBtn\" onclick=\"myFunc('contenedorleidos')\" href=\"javascript: void(0)\" class=\"w3-bar-item w3-teal w3-button\"><i class=\"fa fa-check-circle w3-margin-right\"></i>Leidos(" + row["mensaje"] + ")<i class=\"fa fa-caret-down w3-margin-left\"></i></a>";

                    Response.Write(respuesta);


                }
                respuesta = "";
            }


            //ver usuarios de mensajes leidos
            else if (data == "InboxLeidos")
            {
                DataTable listainbox = BDCO.InboxVistos();
                foreach (DataRow row in listainbox.Rows)
                {
                    respuesta = "<a onclick=\"VerMensa(" + row["idmensaje"] + ",'" + row["nombre"] + "'); w3_close();\" class=\"w3-bar-item w3-button w3-border-bottom test w3-hover-light-grey\" id=\"firstTab\"><div class=\"w3-container\"><img class=\"w3-round w3-margin-right\" src=\"/img/usuario.png\" style=\"width:15%;\"><span class=\"w3-opacity w3-large\">" + row["nombre"] + "</span><h6></h6><p>" + row["email"] + "</p></div></a>";

                    Response.Write(respuesta);

                }
                respuesta = "";
            }

            //responder a traves de correo electronico
            else if (data == "responderinbox")
            {
                try
                {
                    objecontacto.para = Request.Form["para"];
                    objecontacto.asunto = Request.Form["asu"];
                    objecontacto.mensaje = Request.Form["inb"];
                    BDCO.EnviarCorreo(objecontacto);
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("soportegrandtourmid@gmail.com");
                    correo.To.Add(objecontacto.para);
                    correo.Subject = objecontacto.asunto;
                    correo.Body = objecontacto.mensaje;
                    correo.IsBodyHtml = false;
                    correo.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    string cuenta = "soportegrandtourmid@gmail.com";
                    string contra = "peluso182";
                    smtp.Credentials = new System.Net.NetworkCredential(cuenta, contra);
                    smtp.Send(correo);
                    respuesta = "1";
                }

                catch { respuesta = "0"; }


            }

            ///numero o contador de los emails enviados
            else if (data == "inboxnotificenviados")
            {
                DataTable listanotiinbox = BDCO.NumeroEnviado();
                foreach (DataRow row in listanotiinbox.Rows)
                {
                    respuesta = "<a id=\"myBtn\" onclick=\"myFunc('contenedorenviados')\" href=\"javascript: void(0)\" class=\"w3-bar-item w3-teal w3-button\"><i class=\"fa fa-send w3-margin-right\"></i>Enviados(" + row["mensaje"] + ")<i class=\"fa fa-caret-down w3-margin-left\"></i></a>";

                    Response.Write(respuesta);
                }
                respuesta = "";
            }

            //cargar los usuarios a los que se han enviado emails
            else if (data == "usuariosenviados")
            {

                DataTable listaenvie = BDCO.InboxEnviado();
                foreach (DataRow row in listaenvie.Rows)
                {
                    respuesta = "<a onclick=\"VerInbox(" + row["idcorreo"] + ",'" + row["para"] + "');  w3_close();\" class=\"w3-bar-item w3-button w3-border-bottom test w3-hover-light-grey\" id=\"firstTab\"><div class=\"w3-container\"><img class=\"w3-round w3-margin-right\" src=\"/img/usuario.png\" style=\"width:15%;\"><span class=\"w3-opacity w3-large\">" + row["motivo"] + "</span><h6></h6><p>" + row["para"] + "</p></div></a>";

                    Response.Write(respuesta);

                }
                respuesta = "";

            }

            //ver informacion de los mensajes enviados
            else if (data == "verenviado")
            {
                objecontacto.idcontacto = Convert.ToInt32(Request.QueryString["idcorreoenviado"]);
                DataTable visto = BDCO.Verinboxenviado(objecontacto);
                foreach (DataRow row in visto.Rows)
                {
                    respuesta = "<br><img class=\"w3-round  w3-animate-top\" src=\"/img/usuario.png\" style=\"width:20%;\"><h5 id=\"correoresponder\" class=\"w3-opacity\">" + row["para"] + "</h5><h4><i class=\"fa fa-clock-o\">" + row["fecha"] + "</i></h4><hr><p>" + row["mensaje"] + "</p><p>Atte: <br>Soporte Grand Tour MID</p><input name=\"CorreoOculto\" id=\"CorreoOculto\" value=\"" + row["motivo"] + "\" type=\"hidden\"/>";

                    Response.Write(respuesta);
                }

                BDCO.MensajeLeido(objecontacto);

                respuesta = "";

            }

            //numero de usuarios registrados la informacion se muestra en el backend
            else if (data == "numberuser")
            {

                DataTable duser = BDU.NumeroUsuarios();
                foreach (DataRow row in duser.Rows)
                {
                    respuesta = "<h3>" + row["usuario"] + "</h3>";
                    Response.Write(respuesta);
                }
                respuesta = "";
            }

            //numero de mensajes recibidos notificaciones
            else if (data == "messagenew")
            {

                DataTable duser = BDCO.NumeroInbox();
                foreach (DataRow row in duser.Rows)
                {
                    respuesta = "<a href=\"/Admin/ContactInbox\" class=\"w3-bar-item w3-button\"><i class=\"fa fa-envelope\"><span class=\"w3-badge w3-right w3-small w3-green\">" + row["mensaje"] + "</span></i></a>";
                    Response.Write(respuesta);
                }
                respuesta = "";

            }
            //numero de mensajes recibidos en la pagina principal backend
            else if (data == "mensajesnumeroprincipal")
            {
                DataTable listanotiinbox = BDCO.NumeroInbox();
                foreach (DataRow row in listanotiinbox.Rows)
                {

                    respuesta = "<h3>" + row["mensaje"] + "</h3>";

                    Response.Write(respuesta);
                }

                respuesta = "";
            }

            //ejemplo para guardar foto aun no funciona bien
            else if (data == "fotos")
            {
                /* string imgs = Request.Form["file"];
                 string pic = Session["ID"] + "_Gde_" + System.IO.Path.GetFileName(img.FileName);
                 string patc = System.IO.Path.Combine(Server.MapPath("~/img/"), pic);
                 img.SaveAs(patc);
                 objeus.imagen = pic;
                 BDU.Foto(objeus);


                 respuesta = "1";*/

                /* for (int i = 0; i < Request.Files.Count; i++)
                 {
                     var file = Request.Files[i];

                     var fileName = Session["ID"]+"_gde_"+ Path.GetFileName(file.FileName);

                     var path = Path.Combine(Server.MapPath("~/img/"), fileName);
                     file.SaveAs(path);

                     objeus.imagen = fileName;

                     BDU.Foto(objeus);
                 }

                 objeus.imagen = "";
                 respuesta = "1";*/
            }

            //ejemplo de vista previa de publicaciones aun no funciona correctamente
            else if (data == "publicaciones")
            {
                int numero = Convert.ToInt32(Request.QueryString["start"]);
                DataTable Lispubli = BDP.CargarPublicaciones(numero);
                string imagen;


                foreach (DataRow row in Lispubli.Rows)
                {
                    imagen = row["img"].ToString();

                    if (imagen == "")
                    {
                        respuesta = "<br><img src=\"/img/usuario.png\" alt=\"Avatar\" class=\"w3-left w3-circle w3-margin-right\" style=\"width:60px\"><span class=\"w3-right w3-opacity\">32 min</span><h4>" + row["idusuario"] + "</h4><br><hr class=\"w3-clear\"><p>Have you seen this?</p><p>" + row["texto"] + "</p><button type =\"button\" class=\"w3-button w3-theme-d1 w3-margin-bottom\"><i class=\"fa fa-thumbs-up\"></i>  Like</button><button type =\"button\" class=\"w3-button w3-theme-d2 w3-margin-bottom\"><i class=\"fa fa-comment\"></i> Comment</button>";
                    }
                    else
                    {
                        respuesta = "<br><img src=\"/img/usuario.png\" alt=\"Avatar\" class=\"w3-left w3-circle w3-margin-right\" style=\"width:60px\"><span class=\"w3-right w3-opacity\">32 min</span><h4>" + row["idusuario"] + "</h4><br><hr class=\"w3-clear\"><p>Have you seen this?</p><img src=\"" + row["img"] + "\" style=\"width:100%\" class=\"w3-margin-bottom\"><p>" + row["texto"] + "</p><button type =\"button\" class=\"w3-button w3-theme-d1 w3-margin-bottom\"><i class=\"fa fa-thumbs-up\"></i>  Like</button><button type =\"button\" class=\"w3-button w3-theme-d2 w3-margin-bottom\"><i class=\"fa fa-comment\"></i> Comment</button>";
                    }

                    Response.Write(respuesta);


                }


                respuesta = "";
            }

            //carga la informacion de usuarios registrados en un modal
            else if (data == "verinfousuariosregistrados")
            {
                int id = Convert.ToInt32(Request.QueryString["iduser"]);
                DataTable dt = BDU.BuscarUser(id);
                String jSonString = ConvertirDataJson(dt);

                respuesta = jSonString;
            }

            //desactiva la cuenta de usuario
            else if (data == "desactivarcuenta")
            {
                int id = Convert.ToInt32(Request.QueryString["iduser"]);
                BDU.DesactivarCuenta(id);
                respuesta = "1";
            }

            //actualiza información 
            else if (data == "updateacerca")
            {
                objei.titulo = Request.Form["titulo2"];
                objei.subtitulo = Request.Form["subtitulo2"];
                objei.infoapp = Request.Form["infoapp2"];
                objei.infoAdicional = Request.Form["infoadicional2"];
                BDI.ActualizarAcercade(objei);

                respuesta = "1";




            }

            else if (data == "users")
            {
                int iduser = Convert.ToInt32(Session["ID"]);
                objeus.id = iduser;
                ArrayList dates = BDCH.Chat(objeus);
                if (dates.Count > 0)
                {
                    int c = dates.Count / 3;
                    DataTable d = BDCH.usersChat(objeus);
                    for (int i = 0; i < c; i++)
                    {
                        DataRow row = d.Rows[i];
                        respuesta = "<li onclick=\"chatGo(" + row["ID"] + ",'" + row["nombre"] + "');\" class=\"contact\"><div class=\"wrap\"><img src =\"\" alt=\"\" /><div class=\"meta\">" +
                            "<p class=\"name\">" + row["nombre"] + "</p><p class=\"preview\">" + row["email"] + "</p></div></div></li>";
                        Response.Write(respuesta);
                    }


                }
                else
                {
                    Response.Write("No hay usuarios");
                }

                respuesta = "";
            }

            else if (data == "chat")
            {

                objeus.id = Convert.ToInt32(Session["ID"]);
                Session["idchat"] = Request.QueryString["id"].ToString();
                string se = Session["idchat"].ToString();
                objeus.idchat = Convert.ToInt32(Request.QueryString["id"]);
                DataTable d = BDCH.MsgChat(objeus);
                try
                {
                    for (int i = 0; i < d.Rows.Count; i++)
                    {
                        DataRow row = d.Rows[i];

                        if (row["idenvia"].ToString() == Request.QueryString["id"].ToString())
                        {
                            respuesta = "<li class=\"sent\"><img src =\"http://emilcarlsson.se/assets/mikeross.png\" alt=\"\">" +
                                "<p>" + row["mensaje"] + "</p></li>"; Response.Write(respuesta);
                        }
                        else
                        {
                            respuesta = "<li class=\"replies\"><img src=\"http://emilcarlsson.se/assets/harveyspecter.png\" alt =\"\"/>" +
                                "<p>" + row["mensaje"] + "</p>" +
                                "</ li > "; Response.Write(respuesta);
                        }

                    }
                    respuesta = "";
                }
                catch { }

            }
            else if (data == "infouser")
            {
                int id = Convert.ToInt32(Session["idchat"]);
                DataTable dt = BDU.BuscarUser(id);
                String jSonString = ConvertirDataJson(dt);
                respuesta = jSonString;
            }

            else if (data == "enviarchat")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                objeus.idchat = Convert.ToInt32(Session["idchat"]);
                objeus.mensaje = Request.Form["menssage"].ToString();
                ArrayList idChat = BDCH.idChat(objeus);
                if (idChat.Count > 0)
                {
                    objeus.idchat = Convert.ToInt32(idChat[0]);
                    BDCH.Mensajesenviados(objeus);
                    respuesta = "1";
                }
                else
                {
                    Response.Write("Error al enviar mensaje");
                }
            }

            else if (data == "updatetitulo1")
            {
                objei.titulo = Request.Form["titulo1"];
                BDI.ActualizarTitulo1(objei);
                respuesta = "1";
            }
            else if (data == "updatetitulo3")
            {
                objei.titulo3 = Request.Form["titulo3"];
                BDI.ActualizarTitulo3(objei);
                respuesta = "1";
            }
            else if (data == "loadinfo")
            {
                DataTable dti = BDI.CargarInfoInicio();
                String jSonString = ConvertirDataJson(dti);

                respuesta = jSonString;

            }



            return Content(respuesta);
        }



        public ActionResult GuardarImagen1(HttpPostedFileBase file)
        {
            string respuesta = "";
            string pic = System.IO.Path.GetFileName(file.FileName) + "_" + "_Gde_" + ImageFormat.Jpeg;
            string patc = System.IO.Path.Combine(Server.MapPath("~/img"), pic);
            file.SaveAs(patc);
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                byte[] array = ms.GetBuffer();
                objei.img = pic;
                BDI.Actualizarimagen1(objei);


            }

            respuesta = "1";

            return Content(respuesta);


        }


        //metodos fuera del controlador


        public string ConvertirDataJson(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("}");
                    }
                    else
                    {
                        jsonString.Append("},");
                    }
                }
            }
            return jsonString.ToString();
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