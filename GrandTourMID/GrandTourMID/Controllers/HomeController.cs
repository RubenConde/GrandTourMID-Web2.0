using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandTourMID.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View();
            }
            else
            {
                if (idtipo == 1)
                {
                    if (estado == 1)
                    {
                        return Redirect("~/Admin/email");
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
            }
            return Content("");
        }

        public ActionResult Login()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View();
            }
            else
            {
                if (idtipo == 1)
                {
                    if (estado == 1)
                    {
                        return Redirect("~/Admin/email");
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
            }
            return Content("");
        }

        public ActionResult adminlog()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Lugares()
        {
            int idtipo = 0;
            int id = Convert.ToInt32(Session["ID"]);
            idtipo = Convert.ToInt32(Session["idtipo"]);
            int estado = Convert.ToInt32(Session["estado"]);
            if (Session["ID"] == null)
            {
                return View();
            }
            else
            {
                if (idtipo == 1)
                {
                    if (estado == 1)
                    {
                        return Redirect("~/Admin/email");
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
            }
            return Content("");
        }


    }
}