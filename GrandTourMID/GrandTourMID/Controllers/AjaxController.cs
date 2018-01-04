using GrandTourMID.BO;
using GrandTourMID.DAO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        LugarBO objelug = new LugarBO();
        LugarDAO BDLU = new LugarDAO();
        PreguntasBO objp = new PreguntasBO();
        PreguntaDAO BDPRE = new PreguntaDAO();
        // GET: Ajax
        public ActionResult Ajax(String data, UsuarioBO objeus, HttpPostedFileBase file)
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
                    Session.Timeout = 200000;
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
            ///Cerrar sesión
            if (data == "closesesion")
            {

                Session.Abandon();
                Session.RemoveAll();
                Session.Clear();
                respuesta = "1";

            }

            //Recuperando datos en el perfil de usuario
            else if (data == "DatosUsuario")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                int id = objeus.id;
                DataTable dt = BDU.BuscarUser(id);
                String jSonString = ConvertirDataJson(dt);
                respuesta = jSonString;

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
                objeus.contraseña = Request.Form["contraac"];
                string validar = objeus.EncriptarMD5(Request.Form["contraac"]);
                string contra = "";
                ArrayList datos = BDU.ValidarContraseña(objeus);
                if (datos.Count > 0)
                {
                    contra = datos[0].ToString();
                }
                if (validar == contra)
                {
                    objeus.id = Convert.ToInt32(Session["ID"]);
                    objeus.contraseña = Request.Form["contranue"];
                    BDU.ModificarContraseña(objeus);
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
                if (listaus.Rows.Count > 0)
                {
                    foreach (DataRow row in listaus.Rows)
                    {

                        respuesta = "";

                        Response.Write(respuesta);
                    }
                }
                else
                {
                    respuesta = "0";
                }

                respuesta = "";
            }
            //usuarios inactivos
            else if (data == "ListadoUsuariosInactivos")
            {

                DataTable listaus = BDU.BuscarUsuarioInactivo();
                if (listaus.Rows.Count > 0)
                {
                    foreach (DataRow row in listaus.Rows)
                    {

                        respuesta = "";

                        Response.Write(respuesta);
                    }
                }
                else
                {
                    respuesta = "0";
                }

                respuesta = "";
            }
            //usuarios bloqueados
            else if (data == "ListadoUsuariosBloqueados")
            {

                DataTable listaus = BDU.BuscarUsuarioBloqueado();
                if (listaus.Rows.Count > 0)
                {
                    foreach (DataRow row in listaus.Rows)
                    {

                        respuesta = "1";
                        Response.Write(respuesta);
                    }
                }
                else
                {
                    respuesta = "0";
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
                    BDU.ModificarContraseña(objeus);
                    respuesta = "1";
                }
                catch
                {
                    respuesta = "0";
                }



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
            ////ver mensaje notificacaiones
            else if (data == "viewall")
            {
                DataTable listainbox = BDCO.InboxRecibidos();
                foreach (DataRow row in listainbox.Rows)
                {
                    respuesta = "<div onclick=\"VerMensa(" + row["idmensaje"] + ")\" class=\"email-list-item peers fxw-nw p-20 bdB bgcH-grey-100 cur-p\"><div class=\"peer mR-10\"></div><div class=\"peer peer-greed ov-h\"><div class=\"peers ai-c\"><div class=\"peer peer-greed\"><h6>" + row["nombre"] + "</h6></div><div class=\"peer\"><small>" + row["fecha"] + "</small></div></div><h5 class=\"fsz-def tt-c c-grey-900\">" + row["email"] + "</h5><span class=\"whs-nw w-100 ov-h tov-e d-b\">" + row["mensaje"] + "</span></div></div>";
                    Response.Write(respuesta);

                }
                return Content(respuesta);
            }

            //mostrar mensajes recibidos no vistos
            else if (data == "InboxRecibidos")
            {
                DataTable listainbox = BDCO.InboxRecibidos();
                foreach (DataRow row in listainbox.Rows)
                {
                    respuesta = "<div onclick=\"VerMensa(" + row["idmensaje"] + ")\" class=\"email-list-item peers fxw-nw p-20 bdB bgcH-grey-100 cur-p\"><div class=\"peer mR-10\"></div><div class=\"peer peer-greed ov-h\"><div class=\"peers ai-c\"><div class=\"peer peer-greed\"><h6>" + row["nombre"] + "</h6></div><div class=\"peer\"><small>" + row["fecha"] + "</small></div></div><h5 class=\"fsz-def tt-c c-grey-900\">" + row["email"] + "</h5><span class=\"whs-nw w-100 ov-h tov-e d-b\">" + row["mensaje"] + "</span></div></div>";
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
                    respuesta = "<span class=\"badge badge-pill bgc-deep-purple-50 c-deep-purple-700\">" + row["mensaje"] + "</span>";

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
                    respuesta = "<div class=\"h-100 scrollable pos-r ps ps--active-y\"><div class=\"email-content-wrapper\"><div class=\"peers ai-c jc-sb pX-40 pY-30\"><div class=\"peers peer-greed\"><div class=\"peer mR-20\"><img class=\"bdrs-50p w-3r h-3r\" alt=\"\" src=\"https://randomuser.me/api/portraits/men/11.jpg\"></div><div class=\"peer\"><small>" + row["fecha"] + "</small><h5 class=\"c-grey-900 mB-5\">" + row["nombre"] + "</h5><span>email: " + row["email"] + "</span></div></div><div class=\"peer\"><button style=\"cursor:pointer\" type=\"button\" onclick=\"Correo()\" data-toggle=\"modal\" data-target=\"#exampleModal\" class=\"btn btn-danger bdrs-50p p-15 lh-0\"><i  class=\"fa fa-reply\"></i></button></div></div><div class=\"bdT pX-40 pY-30\"><h4>Mensaje</h4><p>" + row["mensaje"] + "</p></div></div><div class=\"ps__rail-x\" style=\"left: 0px; bottom: 0px;\"><div class=\"ps__thumb-x\" tabindex=\"0\" style=\"left: 0px; width: 0px;\"></div></div><div class=\"ps__rail-y\" style=\"top: 0px; height: 618px; right: 0px;\"><div class=\"ps__thumb-y\" tabindex=\"0\" style=\"top: 0px; height: 608px;\"></div></div></div><input id=\"CorreoOculto\" value=\"" + row["email"] + "\" type=\"hidden\">";

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
                    respuesta = "<span class=\"badge badge-pill bgc-blue-50 c-blue-700\">" + row["mensaje"] + "</span>";

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
                    respuesta = "<div onclick=\"VerMensa(" + row["idmensaje"] + ")\" class=\"email-list-item peers fxw-nw p-20 bdB bgcH-grey-100 cur-p\"><div class=\"peer mR-10\"></div><div class=\"peer peer-greed ov-h\"><div class=\"peers ai-c\"><div class=\"peer peer-greed\"><h6>" + row["nombre"] + "</h6></div><div class=\"peer\"><small>" + row["fecha"] + "</small></div></div><h5 class=\"fsz-def tt-c c-grey-900\">" + row["email"] + "</h5><span class=\"whs-nw w-100 ov-h tov-e d-b\">" + row["mensaje"] + "</span></div></div>";

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

            else if (data == "ultimosinboxrecibidos")
            {

                DataTable dinboreci = BDCO.ultimosinboxrecibidos();
                if (dinboreci.Rows.Count > 0)
                {
                    foreach (DataRow row in dinboreci.Rows)
                    {
                        respuesta = "<li><a href =\"\" class=\"peers fxw-nw td-n p-20 bdB c-grey-800 cH-blue bgcH-grey-100\"><div class=\"peer mR-15\"><img class=\"w-3r bdrs-50p\" src=\"https://randomuser.me/api/portraits/men/1.jpg\" alt=\"\"></div><div class=\"peer peer-greed\"><div><div class=\"peers jc-sb fxw-nw mB-5\"><div class=\"peer\"><p class=\"fw-500 mB-0\">" + row["nombre"] + "</p></div><div class=\"peer\"><small class=\"fsz-xs\">" + row["fecha"] + "</small></div></div><span class=\"c-grey-600 fsz-sm\">" + row["mensaje"] + "</span></div></div></a></li>";
                        Response.Write(respuesta);
                    }
                }
                else
                {
                    Response.Write("<center></br><span class=\"fsz-sm fw-600 c-grey-900\">No hay mensajes nuevos</span></br></br></center>");
                }


                respuesta = "";
            }


            ///numero o contador de los emails enviados
            else if (data == "inboxnotificenviados")
            {
                DataTable listanotiinbox = BDCO.NumeroEnviado();
                foreach (DataRow row in listanotiinbox.Rows)
                {
                    respuesta = "<span class=\"badge badge-pill bgc-green-50 c-green-700\">" + row["mensaje"] + "</span>";

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
                    respuesta = "<div style=\"cursor:pointer\" onclick=\"VerInbox(" + row["idcorreo"] + ",'" + row["para"] + "')\" class=\"email-list-item peers fxw-nw p-20 bdB bgcH-grey-100 cur-p\"><div class=\"peer mR-10\"></div><div class=\"peer peer-greed ov-h\"><div class=\"peers ai-c\"><div class=\"peer peer-greed\"><h6>" + row["para"] + "</h6></div><div class=\"peer\"><small>" + row["fecha"] + "</small></div></div><h5 class=\"fsz-def tt-c c-grey-900\">" + row["mensaje"] + "</h5><span class=\"whs-nw w-100 ov-h tov-e d-b\">" + row["motivo"] + "</span></div></div>";

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
                    respuesta = "<div class=\"h-100 scrollable pos-r ps ps--active-y\"><div class=\"email-content-wrapper\"><div class=\"peers ai-c jc-sb pX-40 pY-30\"><div class=\"peers peer-greed\"><div class=\"peer mR-20\"><img class=\"bdrs-50p w-3r h-3r\" alt=\"\" src=\"https://randomuser.me/api/portraits/men/11.jpg\"></div><div class=\"peer\"><small>" + row["fecha"] + "</small><h5 class=\"c-grey-900 mB-5\">" + row["para"] + "</h5><span>Asunto : " + row["motivo"] + "</span></div></div><div class=\"peer\"><button style=\"cursor:pointer\" type=\"button\" onclick=\"Correo()\" data-toggle=\"modal\" data-target=\"#exampleModal\" class=\"btn btn-danger bdrs-50p p-15 lh-0\"><i  class=\"fa fa-reply\"></i></button></div></div><div class=\"bdT pX-40 pY-30\"><h4>Mensaje</h4><p>" + row["mensaje"] + "\"</p><p>Atentamente: Grand Tour MID</p></div></div><div class=\"ps__rail-x\" style=\"left: 0px; bottom: 0px;\"><div class=\"ps__thumb-x\" tabindex=\"0\" style=\"left: 0px; width: 0px;\"></div></div><div class=\"ps__rail-y\" style=\"top: 0px; height: 618px; right: 0px;\"><div class=\"ps__thumb-y\" tabindex=\"0\" style=\"top: 0px; height: 608px;\"></div></div></div><input id=\"CorreoOculto\" value=\"" + row["para"] + "\" type=\"hidden\">";

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
                    respuesta = row["mensaje"].ToString();
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
                objei.infoapp = Request.Form["infoapp2"];
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
                        respuesta = "<div onclick=\"chatGo(" + row["ID"] + ",'" + row["nombre"] + "');\" class=\"peers fxw-nw ai-c p-20 bdB bgc-white bgcH-grey-50 cur-p\"><div class=\"peer\"><img src =\"" + row["foto"] + "\" alt=\"\" class=\"w-3r h-3r bdrs-50p\"></div><div class=\"peer peer-greed pL-20\"><h6 class=\"mB-0 lh-1 fw-400\">" + row["nombre"] + "</h6><small class=\"lh-1\">" + row["email"] + "</small></div></div>";
                        Response.Write(respuesta);
                    }


                }
                else
                {
                    Response.Write("<center></br><span class=\"fsz-sm fw-600 c-grey-900\">Ningun mensaje nuevo</span></br></br></center>");
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

                for (int i = 0; i < d.Rows.Count; i++)
                {
                    DataRow row = d.Rows[i];

                    if (row["idenvia"].ToString() == Request.QueryString["id"].ToString())
                    {
                        respuesta = "<div class=\"peers fxw-nw\"><div class=\"peer mR-20\"><img class=\"w-2r bdrs-50p\" src=\"" + row["foto"] + "\" alt=\"\"></div><div class=\"peer peer-greed\"><div class=\"layers ai-fs gapY-5\"><div class=\"layer\"><div class=\"peers fxw-nw ai-c pY-3 pX-10 bgc-white bdrs-2 lh-3/2\"><div class=\"peer mR-10\"><small>" + row["hora"] + "</small></div><div class=\"peer-greed\"><span>" + row["mensaje"] + "</span></div></div></div></div></div></div>";
                        Response.Write(respuesta);
                    }
                    else
                    {
                        respuesta = "<div class=\"peers fxw-nw ai-fe\"><div class=\"peer ord-1 mL-20\"><img class=\"w-2r bdrs-50p\" src=\"" + row["foto"] + "\" alt=\"\"></div><div class=\"peer peer-greed ord-0\"><div class=\"layers ai-fe gapY-10\"><div class=\"layer\"><div class=\"peers fxw-nw ai-c pY-3 pX-10 bgc-white bdrs-2 lh-3/2\"><div class=\"peer mL-10 ord-1\"><small>" + row["hora"] + "</small></div><div class=\"peer-greed ord-0\"><span>" + row["mensaje"] + "</span></div></div></div></div></div></div>";
                        Response.Write(respuesta);
                    }

                }
                respuesta = "";


            }
            else if (data == "chatrecibidos")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                DataTable duser = BDCH.usersnotifica(objeus);
                foreach (DataRow row in duser.Rows)
                {

                    respuesta = " <li><a href=\"\" class=\"peers fxw-nw td-n p-20 bdB c-grey-800 cH-blue bgcH-grey-100\"><div class=\"peer mR-15\"><img class=\"w-3r bdrs-50p\" src=\"https://randomuser.me/api/portraits/men/1.jpg\" alt=\"\"></div><div class=\"peer peer-greed\"><span><span class=\"fw-500\">" + row["nombreus"] + "</span> <span class=\"c-grey-600\">liked your<span class=\"text-dark\">post</span></span></span><p class=\"m-0\"><small class=\"fsz-xs\">5 mins ago</small></p></div></a></li>";

                }


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
                objeus.mensaje = Request.Form["message"].ToString();
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


            else if (data == "updatetitulo4")
            {
                objei.titulo4 = Request.Form["titulo4"];
                BDI.ActualizarTitulo4(objei);
                respuesta = "1";

            }

            else if (data == "GuardarImagen1")
            {
                string imgs = Request.Form["file"];
                string pic = "inicio_GDE" + System.IO.Path.GetFileName(file.FileName);
                string patc = System.IO.Path.Combine(Server.MapPath("~/img/inicio/"), pic);
                file.SaveAs(patc);
                objei.img = "/img/inicio/" + pic;
                BDI.Actualizarimagen1(objei);
                respuesta = "1";

            }

            else if (data == "GuardarImagen2")
            {
                string imgs = Request.Form["file"];
                string pic = "inicio_GDE" + System.IO.Path.GetFileName(file.FileName);
                string patc = System.IO.Path.Combine(Server.MapPath("~/img/inicio/"), pic);
                file.SaveAs(patc);
                objei.img = "/img/inicio/" + pic;
                BDI.Actualizarimagen2(objei);
                respuesta = "1";


            }
            else if (data == "GuardarImagenheader1")
            {
                string imgs = Request.Form["file"];
                string pic = "inicio_GDE" + System.IO.Path.GetFileName(file.FileName);
                string patc = System.IO.Path.Combine(Server.MapPath("~/img/inicio/"), pic);
                file.SaveAs(patc);
                objei.img = "/img/inicio/" + pic;
                BDI.Actualizarimagenheader1(objei);
                respuesta = "1";


            }

            else if (data == "guardarparallax")
            {
                string imgs = Request.Form["file"];
                string pic = "inicio_GDE" + System.IO.Path.GetFileName(file.FileName);
                string patc = System.IO.Path.Combine(Server.MapPath("~/img/inicio/"), pic);
                file.SaveAs(patc);
                objei.img = "/img/inicio/" + pic;
                BDI.Actualizarimagenparallax(objei);
                respuesta = "1";


            }

            else if (data == "guardarparallax2")
            {
                string imgs = Request.Form["file"];
                string pic = "inicio_GDE" + System.IO.Path.GetFileName(file.FileName);
                string patc = System.IO.Path.Combine(Server.MapPath("~/img/inicio/"), pic);
                file.SaveAs(patc);
                objei.img = "/img/inicio/" + pic;
                BDI.Actualizarimagenparallax2(objei);

                respuesta = "1";


            }
            

            else if (data == "loadinfo")
            {
                DataTable dti = BDI.CargarInfoInicio();
                String jSonString = ConvertirDataJson(dti);

                respuesta = jSonString;

            }


            else if (data == "loadimagesinicio")
            {
                DataTable dtimg = BDI.CargarImgsInicio();
                String jSonString = ConvertirDataJson(dtimg);

                respuesta = jSonString;

            }


            else if (data == "userslist")
            {
                DataTable listempl = BDU.MostrarEmpleados();
                String jSonString = ConvertirDataJson(listempl);

                respuesta = jSonString;
            }

            else if (data == "updateinfo")
            {
                objeus.id = Convert.ToInt32(Session["ID"]);
                objeus.nombre = Request.Form["nameadmi"];
                objeus.usuario = Request.Form["useradmi"];
                objeus.apellidop = Request.Form["apepa"];
                objeus.apellidom = Request.Form["apemat"];
                objeus.email = Request.Form["emailadmi"];
                BDU.Actualizarinfoadmi(objeus);
                respuesta = "1";
            }

            else if (data == "guardarfotos")
            {

                if (file != null)
                {

                    objeus.id = Convert.ToInt32(Session["ID"]);
                    string imgs = Request.Form["file"];
                    string pic = Session["ID"] + "_Gde_" + System.IO.Path.GetFileName(file.FileName);
                    string patc = System.IO.Path.Combine(Server.MapPath("~/img/usuarios/"), pic);
                    file.SaveAs(patc);
                    objeus.imagen = "/img/usuarios/" + pic;
                    BDU.ActualizarFotou(objeus);
                    respuesta = "1";
                }
                else
                {

                    respuesta = "0";
                }
                return Content(respuesta);

            }

            else if (data == "addlugar")
            {
                try
                {
                    if (file != null)
                    {
                        string imgs = Request.Form["file"];
                        string pic = "lugar_Gde_" + System.IO.Path.GetFileName(file.FileName);
                        string patc = System.IO.Path.Combine(Server.MapPath("~/img/lugares/"), pic);
                        file.SaveAs(patc);
                        objelug.imagen = "/img/lugares/" + pic;

                        objelug.nombre = Request.Form["namelugar"];
                        objelug.direccion = Request.Form["direccionlugar"];
                        objelug.direccionmaps = Request.Form["txtubicalugar"];
                        objelug.fecha = Request.Form["fechalugar"];
                        objelug.informacionapp = Request.Form["infolugarapp"];
                        objelug.informacionweb = Request.Form["infolugarweb"];
                        objelug.latitud = Request.Form["lalugar"];
                        objelug.longitud = Request.Form["lonlugar"];
                        BDLU.AgregarLugar(objelug);
                        respuesta = "1";
                    }
                    else
                    {
                        respuesta = "0";
                    }
                }
                catch
                {
                    respuesta = "2";
                }



            }

            else if (data == "loadlugares")
            {

                DataTable Lisluga = BDLU.CargarLugares();
                foreach (DataRow row in Lisluga.Rows)
                {
                    respuesta = "<div class=\"col-md-4\"><img src =\"" + row["imagenportada"] + "\" style=\"width:349px; height:313px\" class=\"rounded\"/><h4>" + row["nombre"] + "</h4><p>" + row["direccion"] + "</p><p><br><a onclick=\"verinfolugar(" + row["idlugar"] + ");\" style=\"cursor:pointer; color:white;\" class=\"btn btn-primary\">Más información</a></p></div>";
                    Response.Write(respuesta);
                }

                respuesta = "";

            }

            /////cargar la informacion de lugares
            else if (data == "verinfolugar")
            {
                Session["idlugar"] = Convert.ToInt32(Request.QueryString["idlugar"]);
                respuesta = "1";
            }

            else if (data == "cargarinfolugar")
            {
                int id = Convert.ToInt32(Session["idlugar"]);
                DataTable dt = BDLU.BuscarLugar(id);
                String jSonString = ConvertirDataJson(dt);

                respuesta = jSonString;
            }

            else if (data == "actualizarimagenlugar")
            {

                if (file != null)
                {

                    objelug.idlugar = Convert.ToInt32(Request.Form["idlugar"]);
                    string pic = "lugar_Gde_" + System.IO.Path.GetFileName(file.FileName);
                    string patc = System.IO.Path.Combine(Server.MapPath("~/img/lugares/"), pic);
                    file.SaveAs(patc);
                    objelug.imagen = "/img/lugares/" + pic;
                    BDLU.ActualizarImagenLugar(objelug);
                    respuesta = "1";
                }
                else
                {
                    respuesta = "0";
                }
                return Content(respuesta);

            }

            else if (data == "actualizardatoslugar")
            {
                try
                {
                    objelug.idlugar = Convert.ToInt32(Request.Form["idlugar2"]);
                    objelug.nombre = Request.Form["editnamelugar"];
                    objelug.informacionweb = Request.Form["editinfolugarweb"];
                    objelug.informacionapp = Request.Form["editinfolugarapp"];
                    objelug.direccion = Request.Form["editdireccionlugar"];
                    objelug.fecha = Request.Form["editfechalugar"];
                    BDLU.ActualizarDatosLugar(objelug);
                    respuesta = "1";
                }
                catch { respuesta = "0"; }
            }

            else if (data == "actualizarubicacion")
            {
                try
                {
                    objelug.idlugar = Convert.ToInt32(Request.Form["idlugar3"]);
                    objelug.longitud = Request.Form["editlonlugar"];
                    objelug.latitud = Request.Form["editlalugar"];
                    objelug.direccionmaps = Request.Form["edittxtubicalugar"];
                    BDLU.ActualizarUbicacionLugar(objelug);
                    respuesta = "1";
                }
                catch { respuesta = "0"; }


            }
            else if (data == "tablalugares")
            {
                DataTable dlugares = BDLU.CargarLugares();
                foreach (DataRow row in dlugares.Rows)
                {
                    respuesta = "<tr><td > " + row["idlugar"] + " </td ><td>" + row["nombre"] + "</td><td>" + row["direccion"] + " </td><td><button onclick=\"SeleccionarL(" + row["idlugar"] + ")\" class=\"btn btn-primary small\" style=\"cursor:pointer\" data-dismiss=\"modal\" type=\"button\"><li class=\"fa fa-share-square-o\"></li> Seleccionar</button></td></tr>";
                    Response.Write(respuesta);
                }

                respuesta = "";

            }
            else if (data == "infolugarpreguntas")
            {
                int id = Convert.ToInt32(Request.QueryString["idlugar"]);
                DataTable dt = BDLU.BuscarLugar(id);
                String jSonString = ConvertirDataJson(dt);

                respuesta = jSonString;


            }
            else if (data == "agregarpregunta")
            {
                try
                {
                    objp.pregunta = Request.Form["namepregunta"];
                    objp.idlugar = Convert.ToInt32(Request.Form["idlugarpreguntas"]);
                    objp.correcta = Request.Form["correcta"];
                    objp.respuesta2 = Request.Form["incorrecta1"];
                    objp.respuesta3 = Request.Form["incorrecta2"];
                    objp.respuesta4 = Request.Form["incorrecta3"];
                    BDPRE.AgregarPregunta(objp);
                    respuesta = "1";
                }
                catch { respuesta = "0"; }

            }

            else if (data == "listalugarespreguntas")
            {
                DataTable dlugares = BDLU.CargarLugares();
                foreach (DataRow row in dlugares.Rows)
                {
                    respuesta = "<div class=\"col-md-4\"><img src =\"" + row["imagenportada"] + "\" style=\"width:349px; height:313px\" class=\"rounded\"/><h4>" + row["nombre"] + "</h4><p>Preguntas</p><p><br><button type=\"button\" data-toggle=\"modal\" data-target=\"#modalpreguntas\" onclick=\"Verpreguntas(" + row["idlugar"] + ");\" style=\"cursor:pointer; color:white;\" class=\"btn btn-primary\"><li class=\"fa fa-eye\"></li>  Ver preguntas</button></p></div>";
                    Response.Write(respuesta);
                }

                respuesta = "";

            }

            else if (data == "verpregunatasrespuestas")
            {
                int id = Convert.ToInt32(Request.QueryString["idpreguntas"]);
                DataTable lispre = BDPRE.VerPreguntasLugar(id);
                foreach (DataRow row in lispre.Rows)
                {
                    respuesta = "<tr><td > " + row["idpregunta"] + " </td ><td>" + row["pregunta"] + "</td><td>" + row["correcta"] + " </td><td>" + row["respuesta2"] + "</td><td>" + row["respuesta3"] + "</td><td>" + row["respuesta4"] + "</td><td><button type=\"button\" onclick=\"editarpregunta(" + row["idpregunta"] + ")\" class=\"btn btn-primary\"><li class=\"fa fa-edit\"></li></button></td></tr>";
                    Response.Write(respuesta);


                }
                respuesta = "";

            }

            else if (data == "editquestion")
            {

                Session["idpregunta"] = Convert.ToInt32(Request.QueryString["idpregunta"]);
                respuesta = "1";

            }


            else if (data == "infopreguntaeditar")
            {
                int idpre = Convert.ToInt32(Session["idpregunta"]);
                DataTable dt = BDPRE.verinfopregunta(idpre);
                String jSonString = ConvertirDataJson(dt);

                respuesta = jSonString;



            }

            else if (data == "updatepregunta")
            {
                objp.idlugar = Convert.ToInt32(Request.Form["respuesta"]);
                objp.pregunta = Request.Form["namepreguntaeditar"];
                objp.correcta = Request.Form["editarcorrecta"];
                objp.respuesta2 = Request.Form["editarincorrecta1"];
                objp.respuesta3 = Request.Form["editarincorrecta2"];
                objp.respuesta4 = Request.Form["editarincorrecta3"];
                BDPRE.ActualizarPregunta(objp);
                respuesta = "1";


            }



            return Content(respuesta);
        }

        public ActionResult cargarimagen(HttpPostedFileBase file)
        {
            string respuesta = "";
            if (file != null)
            {


                string path = Server.MapPath("~/img/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                file.SaveAs(path + Path.GetFileName(file.FileName));
                ViewBag.Message = "File uploaded successfully.";


                respuesta = "0";



            }
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
