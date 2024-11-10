using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecomerce.Controllers
{
    public class SeccionTecController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Home()
        {
            return View(); // Esto devolverá la vista Home.cshtml ubicada en /Views/SeccionRopa/Home.cshtml
        }
    }
}