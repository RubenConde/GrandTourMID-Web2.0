using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTourMID.Controllers
{
    public class ComercioController : Controller
    {
        public ActionResult Estadisticas()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");
        }

        public ActionResult ListaPublicidades()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");


        }

        public ActionResult InfoComercio()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");

        }

        public ActionResult AddPubli()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");

        }

        public ActionResult EditPubli()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");


        }

        public ActionResult Scanner()
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
                    return View("~/Admin/email");
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
                    return View();
                }
                else
                {
                    return View("~/Home/Index");
                }
            }
            return Content("");


        }

    }
}
