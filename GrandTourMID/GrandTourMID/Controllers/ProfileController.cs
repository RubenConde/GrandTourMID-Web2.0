using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTourMID.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public new ActionResult Profile()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View("~/Home/Index");
            }
            if (idtipo == 2)
            {
                if(estado == 1)
                {
                    return View();
                }
                else{
                    return View("~/Home/Index");
                }
            }
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View("~/Admi/email");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");
        }

        public ActionResult EditProfile()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View("~/Home/Index");
            }
            if (idtipo == 2)
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
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View("~/Admi/email");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");
        }

        public ActionResult LugaresVisitados()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View("~/Home/Index");
            }
            if (idtipo == 2)
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
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View("~/Admi/email");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");
        }
        public ActionResult InfoLugarVisitado()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View("~/Home/Index");
            }
            if (idtipo == 2)
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
            if (idtipo == 1)
            {
                if (estado == 1)
                {
                    return View("~/Admi/email");
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");
        }

        public ActionResult chatuser()
        {
            return View();
        }
    }
}