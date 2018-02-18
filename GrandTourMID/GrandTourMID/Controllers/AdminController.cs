using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTourMID.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Back()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }


            return Content("");
        }

        public ActionResult UsersRegister()
        {
            return View();
        }

        public ActionResult UsersInactive()
        {
            return View();
        }

        public ActionResult UsersBlocked()
        {
            return View();
        }

        public ActionResult ContactInbox()
        {
            return View();
        }

        public ActionResult EditIndex()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AboutApp()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult IndexEdit()
        {
            return View();
        }

        public ActionResult email()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult Compose()
        {
            return View();
        }
        public ActionResult users()
        {
            return View();
        }

        public ActionResult Myprofile()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Maps()
        {
            return View();
        }

        public ActionResult AddLugar()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult ListaLugares()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult EditarLugar()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult AddPreguntas()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");

        }
        public ActionResult ListaPreguntas()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult EditarPregunta()
        {

            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }

        public ActionResult AddRetos()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }
        public ActionResult ListaRetos()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }
        public ActionResult EditarReto()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return Redirect("~/Home/Index");
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 2)
            {
                if (estado == 1)
                {
                    return View("~/Profile/Profile");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 3)
            {
                if (estado == 1)
                {
                    return View("~/Comercio/Estadisticas");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }

            return Content("");
        }



        public ActionResult UsuariosRegistrados()
        {

            return View();
        }
    }
}