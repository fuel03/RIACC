using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIACC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Home()
        {
            ModelState.AddModelError("Test", "Invalid user/Password");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
