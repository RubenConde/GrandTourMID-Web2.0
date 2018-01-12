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
                return Redirect("~/Profile/Profile");
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
            return View();
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
            return View();
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
            return View();
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
            return View();
        }

        public ActionResult ListaLugares()
        {
            return View();
        }

        public ActionResult EditarLugar()
        {
            return View();
        }

        public ActionResult AddPreguntas()
        {
            return View();

        }
        public ActionResult ListaPreguntas()
        {
            return View();
        }

        public ActionResult EditarPregunta()
        {
            
            return View();
        }

        public ActionResult AddRetos()
        {
            return View();
        }
    }
}